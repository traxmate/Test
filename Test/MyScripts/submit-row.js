(function () {
    var self = this;

    this.Submit = function (quantityId, moduleName, platformName)
    {
    	var inputId = "#" + quantityId;
    	var quantity = $(inputId).val();
    	var url = "Quantity/Calculate?quantity=" + quantity + "&moduleName=" + moduleName + "&platformName=" + platformName;

    	//$.post(url).success(function(data)
    	//{
    	//    alert("get success");
    	//}).error(function(data, status)
    	//{
    	//   alert(status + ", " + data);
        //});

    	var str = "<form method='post' action='" + url + "'></form>";
    	$(str).appendTo("body").submit();
    	$(str).remove();
    };
}());