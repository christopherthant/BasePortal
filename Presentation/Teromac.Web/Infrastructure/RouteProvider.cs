using System.Web.Mvc;
using System.Web.Routing;
using Teromac.Web.Framework.Localization;
using Teromac.Web.Framework.Mvc.Routes;

namespace Teromac.Web.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            //We reordered our routes so the most used ones are on top. It can improve performance.

            //home page
            routes.MapLocalizedRoute("HomePage",
                            "",
                            new { controller = "Home", action = "Index" },
                            new[] { "Teromac.Web.Controllers" });

            ////widgets
            ////we have this route for performance optimization because named routes are MUCH faster than usual Html.Action(...)
            ////and this route is highly used
            //routes.MapRoute("WidgetsByZone",
            //                "widgetsbyzone/",
            //                new { controller = "Widget", action = "WidgetsByZone" },
            //                new[] { "Teromac.Web.Controllers" });

            //login
            routes.MapLocalizedRoute("Login",
                            "login/",
                            new { controller = "Common", action = "Login" },
                            new[] { "Teromac.Web.Controllers" });
            //register
            routes.MapLocalizedRoute("Register",
                            "register/",
                            new { controller = "Customer", action = "Register" },
                            new[] { "Teromac.Web.Controllers" });
            //logout
            routes.MapLocalizedRoute("Logout",
                            "logout/",
                            new { controller = "Common", action = "Logout" },
                            new[] { "Teromac.Web.Controllers" });

                        ////customer account links
            //routes.MapLocalizedRoute("CustomerInfo",
            //                "customer/info",
            //                new { controller = "Customer", action = "Info" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerAddresses",
            //                "customer/addresses",
            //                new { controller = "Customer", action = "Addresses" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerOrders",
            //                "order/history",
            //                new { controller = "Order", action = "CustomerOrders" },
            //                new[] { "Teromac.Web.Controllers" });

            ////contact us
            //routes.MapLocalizedRoute("ContactUs",
            //                "contactus",
            //                new { controller = "Common", action = "ContactUs" },
            //                new[] { "Teromac.Web.Controllers" });
            ////sitemap
            //routes.MapLocalizedRoute("Sitemap",
            //                "sitemap",
            //                new { controller = "Common", action = "Sitemap" },
            //                new[] { "Teromac.Web.Controllers" });

            ////product search
            //routes.MapLocalizedRoute("ProductSearch",
            //                "search/",
            //                new { controller = "Catalog", action = "Search" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ProductSearchAutoComplete",
            //                "catalog/searchtermautocomplete",
            //                new { controller = "Catalog", action = "SearchTermAutoComplete" },
            //                new[] { "Teromac.Web.Controllers" });

            ////change currency (AJAX link)
            //routes.MapLocalizedRoute("ChangeCurrency",
            //                "changecurrency/{customercurrency}",
            //                new { controller = "Common", action = "SetCurrency" },
            //                new { customercurrency = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////change language (AJAX link)
            //routes.MapLocalizedRoute("ChangeLanguage",
            //                "changelanguage/{langid}",
            //                new { controller = "Common", action = "SetLanguage" },
            //                new { langid = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////change tax (AJAX link)
            //routes.MapLocalizedRoute("ChangeTaxType",
            //                "changetaxtype/{customertaxtype}",
            //                new { controller = "Common", action = "SetTaxType" },
            //                new { customertaxtype = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });

            ////recently viewed products
            //routes.MapLocalizedRoute("RecentlyViewedProducts",
            //                "recentlyviewedproducts/",
            //                new { controller = "Product", action = "RecentlyViewedProducts" },
            //                new[] { "Teromac.Web.Controllers" });
            ////new products
            //routes.MapLocalizedRoute("NewProducts",
            //                "newproducts/",
            //                new { controller = "Product", action = "NewProducts" },
            //                new[] { "Teromac.Web.Controllers" });
            ////blog
            //routes.MapLocalizedRoute("Blog",
            //                "blog",
            //                new { controller = "Blog", action = "List" },
            //                new[] { "Teromac.Web.Controllers" });
            ////news
            //routes.MapLocalizedRoute("NewsArchive",
            //                "news",
            //                new { controller = "News", action = "List" },
            //                new[] { "Teromac.Web.Controllers" });

            ////forum
            //routes.MapLocalizedRoute("Boards",
            //                "boards",
            //                new { controller = "Boards", action = "Index" },
            //                new[] { "Teromac.Web.Controllers" });

            ////compare products
            //routes.MapLocalizedRoute("CompareProducts",
            //                "compareproducts/",
            //                new { controller = "Product", action = "CompareProducts" },
            //                new[] { "Teromac.Web.Controllers" });

            ////product tags
            //routes.MapLocalizedRoute("ProductTagsAll",
            //                "producttag/all/",
            //                new { controller = "Catalog", action = "ProductTagsAll" },
            //                new[] { "Teromac.Web.Controllers" });

            ////manufacturers
            //routes.MapLocalizedRoute("ManufacturerList",
            //                "manufacturer/all/",
            //                new { controller = "Catalog", action = "ManufacturerAll" },
            //                new[] { "Teromac.Web.Controllers" });
            ////vendors
            //routes.MapLocalizedRoute("VendorList",
            //                "vendor/all/",
            //                new { controller = "Catalog", action = "VendorAll" },
            //                new[] { "Teromac.Web.Controllers" });


            ////add product to cart (without any attributes and options). used on catalog pages.
            //routes.MapLocalizedRoute("AddProductToCart-Catalog",
            //                "addproducttocart/catalog/{productId}/{shoppingCartTypeId}/{quantity}",
            //                new { controller = "ShoppingCart", action = "AddProductToCart_Catalog" },
            //                new { productId = @"\d+", shoppingCartTypeId = @"\d+", quantity = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////add product to cart (with attributes and options). used on the product details pages.
            //routes.MapLocalizedRoute("AddProductToCart-Details",
            //                "addproducttocart/details/{productId}/{shoppingCartTypeId}",
            //                new { controller = "ShoppingCart", action = "AddProductToCart_Details" },
            //                new { productId = @"\d+", shoppingCartTypeId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });

            ////product tags
            //routes.MapLocalizedRoute("ProductsByTag",
            //                "producttag/{productTagId}/{SeName}",
            //                new { controller = "Catalog", action = "ProductsByTag", SeName = UrlParameter.Optional },
            //                new { productTagId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////comparing products
            //routes.MapLocalizedRoute("AddProductToCompare",
            //                "compareproducts/add/{productId}",
            //                new { controller = "Product", action = "AddProductToCompareList" },
            //                new { productId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////product email a friend
            //routes.MapLocalizedRoute("ProductEmailAFriend",
            //                "productemailafriend/{productId}",
            //                new { controller = "Product", action = "ProductEmailAFriend" },
            //                new { productId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////reviews
            //routes.MapLocalizedRoute("ProductReviews",
            //                "productreviews/{productId}",
            //                new { controller = "Product", action = "ProductReviews" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerProductReviews",
            //                "customer/productreviews",
            //                new { controller = "Product", action = "CustomerProductReviews" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerProductReviewsPaged",
            //                "customer/productreviews/page/{page}",
            //                new { controller = "Product", action = "CustomerProductReviews" },
            //                new { page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////back in stock notifications
            //routes.MapLocalizedRoute("BackInStockSubscribePopup",
            //                "backinstocksubscribe/{productId}",
            //                new { controller = "BackInStockSubscription", action = "SubscribePopup" },
            //                new { productId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("BackInStockSubscribeSend",
            //                "backinstocksubscribesend/{productId}",
            //                new { controller = "BackInStockSubscription", action = "SubscribePopupPOST" },
            //                new { productId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////downloads
            //routes.MapRoute("GetSampleDownload",
            //                "download/sample/{productid}",
            //                new { controller = "Download", action = "Sample" },
            //                new { productid = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });



            ////checkout pages
            //routes.MapLocalizedRoute("Checkout",
            //                "checkout/",
            //                new { controller = "Checkout", action = "Index" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutOnePage",
            //                "onepagecheckout/",
            //                new { controller = "Checkout", action = "OnePageCheckout" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutShippingAddress",
            //                "checkout/shippingaddress",
            //                new { controller = "Checkout", action = "ShippingAddress" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutSelectShippingAddress",
            //                "checkout/selectshippingaddress",
            //                new { controller = "Checkout", action = "SelectShippingAddress" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutBillingAddress",
            //                "checkout/billingaddress",
            //                new { controller = "Checkout", action = "BillingAddress" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutSelectBillingAddress",
            //                "checkout/selectbillingaddress",
            //                new { controller = "Checkout", action = "SelectBillingAddress" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutShippingMethod",
            //                "checkout/shippingmethod",
            //                new { controller = "Checkout", action = "ShippingMethod" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutPaymentMethod",
            //                "checkout/paymentmethod",
            //                new { controller = "Checkout", action = "PaymentMethod" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutPaymentInfo",
            //                "checkout/paymentinfo",
            //                new { controller = "Checkout", action = "PaymentInfo" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutConfirm",
            //                "checkout/confirm",
            //                new { controller = "Checkout", action = "Confirm" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CheckoutCompleted",
            //                "checkout/completed/{orderId}",
            //                new { controller = "Checkout", action = "Completed", orderId = UrlParameter.Optional },
            //                new { orderId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });

            ////subscribe newsletters
            //routes.MapLocalizedRoute("SubscribeNewsletter",
            //                "subscribenewsletter",
            //                new { controller = "Newsletter", action = "SubscribeNewsletter" },
            //                new[] { "Teromac.Web.Controllers" });

            ////email wishlist
            //routes.MapLocalizedRoute("EmailWishlist",
            //                "emailwishlist",
            //                new { controller = "ShoppingCart", action = "EmailWishlist" },
            //                new[] { "Teromac.Web.Controllers" });

            ////login page for checkout as guest
            //routes.MapLocalizedRoute("LoginCheckoutAsGuest",
            //                "login/checkoutasguest",
            //                new { controller = "Customer", action = "Login", checkoutAsGuest = true },
            //                new[] { "Teromac.Web.Controllers" });
            ////register result page
            //routes.MapLocalizedRoute("RegisterResult",
            //                "registerresult/{resultId}",
            //                new { controller = "Customer", action = "RegisterResult" },
            //                new { resultId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////check username availability
            //routes.MapLocalizedRoute("CheckUsernameAvailability",
            //                "customer/checkusernameavailability",
            //                new { controller = "Customer", action = "CheckUsernameAvailability" },
            //                new[] { "Teromac.Web.Controllers" });

            ////passwordrecovery
            //routes.MapLocalizedRoute("PasswordRecovery",
            //                "passwordrecovery",
            //                new { controller = "Customer", action = "PasswordRecovery" },
            //                new[] { "Teromac.Web.Controllers" });
            ////password recovery confirmation
            //routes.MapLocalizedRoute("PasswordRecoveryConfirm",
            //                "passwordrecovery/confirm",
            //                new { controller = "Customer", action = "PasswordRecoveryConfirm" },                            
            //                new[] { "Teromac.Web.Controllers" });

            ////topics
            //routes.MapLocalizedRoute("TopicPopup",
            //                "t-popup/{SystemName}",
            //                new { controller = "Topic", action = "TopicDetailsPopup" },
            //                new[] { "Teromac.Web.Controllers" });
            
            ////blog
            //routes.MapLocalizedRoute("BlogByTag",
            //                "blog/tag/{tag}",
            //                new { controller = "Blog", action = "BlogByTag" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("BlogByMonth",
            //                "blog/month/{month}",
            //                new { controller = "Blog", action = "BlogByMonth" },
            //                new[] { "Teromac.Web.Controllers" });
            ////blog RSS
            //routes.MapLocalizedRoute("BlogRSS",
            //                "blog/rss/{languageId}",
            //                new { controller = "Blog", action = "ListRss" },
            //                new { languageId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });

            ////news RSS
            //routes.MapLocalizedRoute("NewsRSS",
            //                "news/rss/{languageId}",
            //                new { controller = "News", action = "ListRss" },
            //                new { languageId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });

            ////set review helpfulness (AJAX link)
            //routes.MapRoute("SetProductReviewHelpfulness",
            //                "setproductreviewhelpfulness",
            //                new { controller = "Product", action = "SetProductReviewHelpfulness" },
            //                new[] { "Teromac.Web.Controllers" });

            ////customer account links
            //routes.MapLocalizedRoute("CustomerReturnRequests",
            //                "returnrequest/history",
            //                new { controller = "ReturnRequest", action = "CustomerReturnRequests" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerDownloadableProducts",
            //                "customer/downloadableproducts",
            //                new { controller = "Customer", action = "DownloadableProducts" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerBackInStockSubscriptions",
            //                "backinstocksubscriptions/manage",
            //                new { controller = "BackInStockSubscription", action = "CustomerSubscriptions" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerBackInStockSubscriptionsPaged",
            //                "backinstocksubscriptions/manage/{page}",
            //                new { controller = "BackInStockSubscription", action = "CustomerSubscriptions", page = UrlParameter.Optional },
            //                new { page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerRewardPoints",
            //                "rewardpoints/history",
            //                new { controller = "Order", action = "CustomerRewardPoints" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerRewardPointsPaged",
            //                "rewardpoints/history/page/{page}",
            //                new { controller = "Order", action = "CustomerRewardPoints" },
            //                new { page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerChangePassword",
            //                "customer/changepassword",
            //                new { controller = "Customer", action = "ChangePassword" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerAvatar",
            //                "customer/avatar",
            //                new { controller = "Customer", action = "Avatar" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("AccountActivation",
            //                "customer/activation",
            //                new { controller = "Customer", action = "AccountActivation" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerForumSubscriptions",
            //                "boards/forumsubscriptions",
            //                new { controller = "Boards", action = "CustomerForumSubscriptions" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerForumSubscriptionsPaged",
            //                "boards/forumsubscriptions/{page}",
            //                new { controller = "Boards", action = "CustomerForumSubscriptions", page = UrlParameter.Optional },
            //                new { page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerAddressEdit",
            //                "customer/addressedit/{addressId}",
            //                new { controller = "Customer", action = "AddressEdit" },
            //                new { addressId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerAddressAdd",
            //                "customer/addressadd",
            //                new { controller = "Customer", action = "AddressAdd" },
            //                new[] { "Teromac.Web.Controllers" });
            ////customer profile page
            //routes.MapLocalizedRoute("CustomerProfile",
            //                "profile/{id}",
            //                new { controller = "Profile", action = "Index" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("CustomerProfilePaged",
            //                "profile/{id}/page/{page}",
            //                new { controller = "Profile", action = "Index" },
            //                new { id = @"\d+", page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });

            ////orders
            //routes.MapLocalizedRoute("OrderDetails",
            //                "orderdetails/{orderId}",
            //                new { controller = "Order", action = "Details" },
            //                new { orderId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ShipmentDetails",
            //                "orderdetails/shipment/{shipmentId}",
            //                new { controller = "Order", action = "ShipmentDetails" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ReturnRequest",
            //                "returnrequest/{orderId}",
            //                new { controller = "ReturnRequest", action = "ReturnRequest" },
            //                new { orderId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ReOrder",
            //                "reorder/{orderId}",
            //                new { controller = "Order", action = "ReOrder" },
            //                new { orderId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("GetOrderPdfInvoice",
            //                "orderdetails/pdf/{orderId}",
            //                new { controller = "Order", action = "GetPdfInvoice" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("PrintOrderDetails",
            //                "orderdetails/print/{orderId}",
            //                new { controller = "Order", action = "PrintOrderDetails" },
            //                new[] { "Teromac.Web.Controllers" });
            ////order downloads
            //routes.MapRoute("GetDownload",
            //                "download/getdownload/{orderItemId}/{agree}",
            //                new { controller = "Download", action = "GetDownload", agree = UrlParameter.Optional },
            //                new { orderItemId = new GuidConstraint(false) },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapRoute("GetLicense",
            //                "download/getlicense/{orderItemId}/",
            //                new { controller = "Download", action = "GetLicense" },
            //                new { orderItemId = new GuidConstraint(false) },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("DownloadUserAgreement",
            //                "customer/useragreement/{orderItemId}",
            //                new { controller = "Customer", action = "UserAgreement" },
            //                new { orderItemId = new GuidConstraint(false) },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapRoute("GetOrderNoteFile",
            //                "download/ordernotefile/{ordernoteid}",
            //                new { controller = "Download", action = "GetOrderNoteFile" },
            //                new { ordernoteid = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });

            ////contact vendor
            //routes.MapLocalizedRoute("ContactVendor",
            //                "contactvendor/{vendorId}",
            //                new { controller = "Common", action = "ContactVendor" },
            //                new[] { "Teromac.Web.Controllers" });
            ////apply for vendor account
            //routes.MapLocalizedRoute("ApplyVendorAccount",
            //                "vendor/apply",
            //                new { controller = "Vendor", action = "ApplyVendor" },
            //                new[] { "Teromac.Web.Controllers" });
            ////vendor info
            //routes.MapLocalizedRoute("CustomerVendorInfo",
            //                "customer/vendorinfo",
            //                new { controller = "Vendor", action = "Info" },
            //                new[] { "Teromac.Web.Controllers" });

            ////poll vote AJAX link
            //routes.MapLocalizedRoute("PollVote",
            //                "poll/vote",
            //                new { controller = "Poll", action = "Vote" },
            //                new[] { "Teromac.Web.Controllers" });

            ////comparing products
            //routes.MapLocalizedRoute("RemoveProductFromCompareList",
            //                "compareproducts/remove/{productId}",
            //                new { controller = "Product", action = "RemoveProductFromCompareList" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ClearCompareList",
            //                "clearcomparelist/",
            //                new { controller = "Product", action = "ClearCompareList" },
            //                new[] { "Teromac.Web.Controllers" });

            ////new RSS
            //routes.MapLocalizedRoute("NewProductsRSS",
            //                "newproducts/rss",
            //                new { controller = "Product", action = "NewProductsRss" },
            //                new[] { "Teromac.Web.Controllers" });
            
            ////get state list by country ID  (AJAX link)
            //routes.MapRoute("GetStatesByCountryId",
            //                "country/getstatesbycountryid/",
            //                new { controller = "Country", action = "GetStatesByCountryId" },
            //                new[] { "Teromac.Web.Controllers" });

            ////EU Cookie law accept button handler (AJAX link)
            //routes.MapRoute("EuCookieLawAccept",
            //                "eucookielawaccept",
            //                new { controller = "Common", action = "EuCookieLawAccept" },
            //                new[] { "Teromac.Web.Controllers" });

            ////authenticate topic AJAX link
            //routes.MapLocalizedRoute("TopicAuthenticate",
            //                "topic/authenticate",
            //                new { controller = "Topic", action = "Authenticate" },
            //                new[] { "Teromac.Web.Controllers" });

            ////product attributes with "upload file" type
            //routes.MapLocalizedRoute("UploadFileProductAttribute",
            //                "uploadfileproductattribute/{attributeId}",
            //                new { controller = "ShoppingCart", action = "UploadFileProductAttribute" },
            //                new { attributeId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            ////checkout attributes with "upload file" type
            //routes.MapLocalizedRoute("UploadFileCheckoutAttribute",
            //                "uploadfilecheckoutattribute/{attributeId}",
            //                new { controller = "ShoppingCart", action = "UploadFileCheckoutAttribute" },
            //                new { attributeId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            
            ////forums
            //routes.MapLocalizedRoute("ActiveDiscussions",
            //                "boards/activediscussions",
            //                new { controller = "Boards", action = "ActiveDiscussions" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ActiveDiscussionsPaged",
            //                "boards/activediscussions/page/{page}",
            //                new { controller = "Boards", action = "ActiveDiscussions", page = UrlParameter.Optional },
            //                new { page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ActiveDiscussionsRSS",
            //                "boards/activediscussionsrss",
            //                new { controller = "Boards", action = "ActiveDiscussionsRSS" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("PostEdit",
            //                "boards/postedit/{id}",
            //                new { controller = "Boards", action = "PostEdit" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("PostDelete",
            //                "boards/postdelete/{id}",
            //                new { controller = "Boards", action = "PostDelete" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("PostCreate",
            //                "boards/postcreate/{id}",
            //                new { controller = "Boards", action = "PostCreate" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("PostCreateQuote",
            //                "boards/postcreate/{id}/{quote}",
            //                new { controller = "Boards", action = "PostCreate" },
            //                new { id = @"\d+", quote = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("TopicEdit",
            //                "boards/topicedit/{id}",
            //                new { controller = "Boards", action = "TopicEdit" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("TopicDelete",
            //                "boards/topicdelete/{id}",
            //                new { controller = "Boards", action = "TopicDelete" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("TopicCreate",
            //                "boards/topiccreate/{id}",
            //                new { controller = "Boards", action = "TopicCreate" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("TopicMove",
            //                "boards/topicmove/{id}",
            //                new { controller = "Boards", action = "TopicMove" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("TopicWatch",
            //                "boards/topicwatch/{id}",
            //                new { controller = "Boards", action = "TopicWatch" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("TopicSlug",
            //                "boards/topic/{id}/{slug}",
            //                new { controller = "Boards", action = "Topic", slug = UrlParameter.Optional },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("TopicSlugPaged",
            //                "boards/topic/{id}/{slug}/page/{page}",
            //                new { controller = "Boards", action = "Topic", slug = UrlParameter.Optional, page = UrlParameter.Optional },
            //                new { id = @"\d+", page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ForumWatch",
            //                "boards/forumwatch/{id}",
            //                new { controller = "Boards", action = "ForumWatch" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ForumRSS",
            //                "boards/forumrss/{id}",
            //                new { controller = "Boards", action = "ForumRSS" },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ForumSlug",
            //                "boards/forum/{id}/{slug}",
            //                new { controller = "Boards", action = "Forum", slug = UrlParameter.Optional },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ForumSlugPaged",
            //                "boards/forum/{id}/{slug}/page/{page}",
            //                new { controller = "Boards", action = "Forum", slug = UrlParameter.Optional, page = UrlParameter.Optional },
            //                new { id = @"\d+", page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ForumGroupSlug",
            //                "boards/forumgroup/{id}/{slug}",
            //                new { controller = "Boards", action = "ForumGroup", slug = UrlParameter.Optional },
            //                new { id = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("Search",
            //                "boards/search",
            //                new { controller = "Boards", action = "Search" },
            //                new[] { "Teromac.Web.Controllers" });

            ////private messages
            //routes.MapLocalizedRoute("PrivateMessages",
            //                "privatemessages/{tab}",
            //                new { controller = "PrivateMessages", action = "Index", tab = UrlParameter.Optional },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("PrivateMessagesPaged",
            //                "privatemessages/{tab}/page/{page}",
            //                new { controller = "PrivateMessages", action = "Index", tab = UrlParameter.Optional },
            //                new { page = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("PrivateMessagesInbox",
            //                "inboxupdate",
            //                new { controller = "PrivateMessages", action = "InboxUpdate" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("PrivateMessagesSent",
            //                "sentupdate",
            //                new { controller = "PrivateMessages", action = "SentUpdate" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("SendPM",
            //                "sendpm/{toCustomerId}",
            //                new { controller = "PrivateMessages", action = "SendPM" },
            //                new { toCustomerId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("SendPMReply",
            //                "sendpm/{toCustomerId}/{replyToMessageId}",
            //                new { controller = "PrivateMessages", action = "SendPM" },
            //                new { toCustomerId = @"\d+", replyToMessageId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("ViewPM",
            //                "viewpm/{privateMessageId}",
            //                new { controller = "PrivateMessages", action = "ViewPM" },
            //                new { privateMessageId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });
            //routes.MapLocalizedRoute("DeletePM",
            //                "deletepm/{privateMessageId}",
            //                new { controller = "PrivateMessages", action = "DeletePM" },
            //                new { privateMessageId = @"\d+" },
            //                new[] { "Teromac.Web.Controllers" });

            ////activate newsletters
            //routes.MapLocalizedRoute("NewsletterActivation",
            //                "newsletter/subscriptionactivation/{token}/{active}",
            //                new { controller = "Newsletter", action = "SubscriptionActivation" },
            //                new { token = new GuidConstraint(false) },
            //                new[] { "Teromac.Web.Controllers" });

            ////robots.txt
            //routes.MapRoute("robots.txt",
            //                "robots.txt",
            //                new { controller = "Common", action = "RobotsTextFile" },
            //                new[] { "Teromac.Web.Controllers" });

            ////sitemap (XML)
            //routes.MapLocalizedRoute("sitemap.xml",
            //                "sitemap.xml",
            //                new { controller = "Common", action = "SitemapXml" },
            //                new[] { "Teromac.Web.Controllers" });

            ////store closed
            //routes.MapLocalizedRoute("StoreClosed",
            //                "storeclosed",
            //                new { controller = "Common", action = "StoreClosed" },
            //                new[] { "Teromac.Web.Controllers" });

            ////install
            //routes.MapRoute("Installation",
            //                "install",
            //                new { controller = "Install", action = "Index" },
            //                new[] { "Teromac.Web.Controllers" });
            
            ////page not found
            //routes.MapLocalizedRoute("PageNotFound",
            //                "page-not-found",
            //                new { controller = "Common", action = "PageNotFound" },
            //                new[] { "Teromac.Web.Controllers" });
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
