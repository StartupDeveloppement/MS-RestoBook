$(document).ready(function () {
    $("#SearchString").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Home/AutoCompleteGetSearch/",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        if (item.Ville != null) {
                            return { ville: item.Ville, value: item.Ville };
                        }
                        else if (item.Nom != undefined) {
                            return {
                                    adresse: item.Adresse,
                                    nomRestaurant: item.Nom,
                                    value: item.Nom + "," + item.Adresse
                            }
                        }
                    }));
                },
            }); 
        },
    }).autocomplete("instance")._renderItem = function (ul, item) {
        var result;
      
        if (item.ville != null) {
            result = $("<li>")
            .append("<i class='fa fa-map-marker' style='padding-right:5px'/>" + item.ville)
            .appendTo(".ui-autocomplete ");
        }
        if (item.nomRestaurant != undefined) {
            result =  $("<li>")
           .append(item.nomRestaurant + "<br><i>" + item.adresse + '</i>')
           .appendTo(".ui-autocomplete ");
        }
      
        return result;
    };

    $("#m_ville_lb_ville").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Restaurant/AutoCompleteGetVille/",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Ville,
                        };
                    }));
                }
            });
        }
    });
});











