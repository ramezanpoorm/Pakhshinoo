const cookieName = "cart-items";

function addToCart(id, name, price, picture) {
    let products = jQuery.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = jQuery("#productCount").val();
    const currentProduct = products.find(x => x.id === id);
    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            unitPrice: price,
            picture,
            count
        }

        products.push(product);
    }

    jQuery.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}

function updateCart() {
    let products = jQuery.cookie(cookieName);
    products = JSON.parse(products);
    jQuery("#cart_items_count").text(products.length);
    jQuery("#cart_items_count2").text(products.length);
    const cartItemsWrapper = jQuery("#cart_items_wrapper");
    cartItemsWrapper.html('');
    products.forEach(x => {
        const product = `
		<li class="products-mini-cart-item mini_cart_item">
			<div class="mini_cart_item_right">
			<a  href="#" class="remove remove_from_cart_button" onclick="removeFromCart('${x.id}')">×</a>
			<a href="#">
				<img src="/ProductPictures/${x.picture}" class="attachment-products_thumbnail size-products_thumbnail" alt="">
			</a>
			</div>
					<div class="mini_cart_item_left">
			<a href="#">${x.name}</a>
			<div class="mini_cart_quantity_price_row">
				<div class="price">
		<span class="products-Price-amount amount"><bdi>&nbsp;<span class="products-Price-currencySymbol">تومان ${x.unitPrice}</span></bdi></span>
				</div>
		<div class="quantity">
			<label class="screen-reader-text">${x.name}</label>
		<input type="number" class="input-text qty text" step="1" min="1" max="" value="${x.count}" title="تعداد" size="4" placeholder="" inputmode="numeric">
			<div class="plus-minus">
				<div class="increase elm_qty fal fa-plus"></div>
				<div class="reduced elm_qty fal fa-minus"></div>
			</div>
		</div>
			</div>
				</div>
		</li>`;

        cartItemsWrapper.append(product);
    });
}

function removeFromCart(id) {
    let products = jQuery.cookie(cookieName);
    products = JSON.parse(products);
    const itemToRemove = products.findIndex(x => x.id === id);
    products.splice(itemToRemove, 1);
    jQuery.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}

function changeCartItemCount(id, totalId, count) {
    var products = jQuery.cookie(cookieName);
    products = JSON.parse(products);
    const productIndex = products.findIndex(x => x.id == id);
    products[productIndex].count = count;
    const product = products[productIndex];
    const newPrice = parseInt(product.unitPrice) * parseInt(count);
    jQuery(`#${totalId}`).text(newPrice);
    //products[productIndex].totalPrice = newPrice;
    jQuery.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();

    //const data = {
    //    'productId': parseInt(id),
    //    'count': parseInt(count)
    //};

    //$.ajax({
    //    url: url,
    //    type: "post",
    //    data: JSON.stringify(data),
    //    contentType: "application/json",
    //    dataType: "json",
    //    success: function (data) {
    //        if (data.isInStock == false) {
    //            const warningsDiv = $('#productStockWarnings');
    //            if ($(`#${id}-${colorId}`).length == 0) {
    //                warningsDiv.append(`<div class="alert alert-warning" id="${id}-${colorId}">
    //                    <i class="fa fa-exclamation-triangle"></i>
    //                    <span>
    //                        <strong>${data.productName} - ${color
    //                    } </strong> در حال حاضر در انبار موجود نیست. <strong>${data.supplyDays
    //                    } روز</strong> زمان برای تامین آن نیاز است. ادامه مراحل به منزله تایید این زمان است.
    //                    </span>
    //                </div>
    //                `);
    //            }
    //        } else {
    //            if ($(`#${id}-${colorId}`).length > 0) {
    //                $(`#${id}-${colorId}`).remove();
    //            }
    //        }
    //    },
    //    error: function (data) {
    //        alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
    //    }
    //});


    const settings = {
        "url": "https://localhost:5001/api/inventory",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({ "productId": id, "count": count })
    };

    jQuery.ajax(settings).done(function (data) {
        if (data.isStock == false) {
            const warningsDiv = jQuery('#productStockWarnings');
            if (jQuery(`#${id}`).length == 0) {
                warningsDiv.append(`
                    <div class="alert alert-warning" id="${id}">
                        <i class="fa fa-warning"></i> کالای
                        <strong>${data.productName}</strong>
                        در انبار کمتر از تعداد درخواستی موجود است.
                    </div>
                `);
            }
        } else {
            if (jQuey(`#${id}`).length > 0) {
                jQuery(`#${id}`).remove();
            }
        }
    });
}