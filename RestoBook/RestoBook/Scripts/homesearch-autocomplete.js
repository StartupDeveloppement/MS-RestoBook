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
                                //ville: item.Ville,
                                adresse: item.Adresse,
                                nomrestaurant: item.Nom,
                                //value: item.Nom+", "+item.R_Adresse
                            };
                        }));
                    }
                },
                //select: function (event, ui) {
                //    $("#SearchString").val(item.adresse);
                //    return false;
                //}
            });
        }
    }).autocomplete("instance")._renderItem = function (ul, item) {


        if(!item.nomRestaurant) {
            return $("<li>")
                .append(item.label)
                .appendTo(".ui-autocomplete ");
        }

        //if (!item.label)
        //{
            return $("<li>")
            .append(item.nomrestaurant + "<br><i>" + item.adresse + '</i>')
            .appendTo(".ui-autocomplete ");
        //}



       
        //if(!item.nomRestaurant) {
        //    return $("<li>")
        //        .append(item.label)
        //        .appendTo(".ui-autocomplete ");
        //}
        //else {
            

            //$("<li>")
            //.append(item.ville)
            //.appendTo(".ui-autocomplete ");

            //$.each(item.label, function (key, value) {
               //return  $("<li>")
               // .append(item.label + "<br><i>" + item.adresse+ '</i>')
               // .appendTo(".ui-autocomplete ");
           

        //}
    };
});











