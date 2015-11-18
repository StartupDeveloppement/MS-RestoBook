$(document).ready(function () {
    $("#SearchString").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "/Home/AutoCompleteGetSearch/",
                data: { term: request.term },
                success: function (data) {
                    if (!data.length) {
                        var r = [{
                            label: "Emplacement ou restaurant non repertorie",
                        }];
                        response(r);
                    } else {
                        response($.map(data, function (item) {


                            return {
                                ville: item.Ville,
                                adresse: item.Addresse,
                                nomRestaurant: item.Nom,
                                value: item.Nom + ", " + item.Adresse,
                            };
                        }));
                    }
                },
                //select: function (event, ui) {
                //    alert("ok");
                //    //$("#SearchString").val(item.adresse);
                //    //return false;
                //}
            });
        }
    
    }).autocomplete("instance")._renderItem = function (ul, item) {

        console.log(item.nomRestaurant);

        //    //if(!item.nomRestaurant) {
        //    //    return $("<li>")
        //    //        .append(item.label)
        //    //        .appendTo(".ui-autocomplete ");
        //    //}

        //    //else{
        //        //return $("<li>")
        //        //.append(item.nomRestaurant + "<br><i>" + item.adresse + '</i>')
        //        //.appendTo(".ui-autocomplete ");   //    }


        if(item.ville != undefined)
        {
            $("<li>")
           .append(item.ville)
           .appendTo(".ui-autocomplete ");
        }
            return $("<li>")
            .append(item.nomRestaurant + "<br><i>" + item.adresse + '</i>')
            .appendTo(".ui-autocomplete ");
            //return $("<li>")
            //.append(item.nomRestaurant + "<br><i>" + item.adresse + '</i>')
            //.appendto(".ui-autocomplete ");
 



       
        
  
    };
});











