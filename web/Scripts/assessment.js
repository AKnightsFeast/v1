(function ($) {
    function GetPerson(cls, useMargins, index, indexNum) {
        return $("<div class='" + cls + "'" + (useMargins ? " style='margin-top: 10px; margin-bottom: 10px'" : "") + "><input type='hidden' name='People.Index' value='" + index + "' /></div>").append(
            $(
                "<div class='field'>" +
                    "<div>" +
                        "<input class='fname entry required' id='People_" + index + "__FirstName' name='People[" + index + "].FirstName' title='First Name' type='text' maxlength='30' style='width: 250px' />" +
                        "<div><label for='People_" + index + "__FirstName'>* First Name</label></div>" +
                    "</div>" +
                    "<div>" +
                        "<input class='lname entry required' id='People_" + index + "__LastName' name='People[" + index + "].LastName' title='Last Name' type='text' maxlength='50' style='width: 380px' />" +
                        "<div><label for='People_" + index + "__LastName'>* Last Name</label></div>" +
                    "</div>" +
                    "<div>" +
                        "<input class='entry' id='People_" + index + "__MiddleInitial' name='People[" + index + "].MiddleInitial' title='Middle Initial' type='text' maxlength='1' style='width: 20px' />" +
                        "<div><label for='People_" + index + "__MiddleInitial'>M.I.</label></div>" +
                    "</div>" +
                "</div>"
            )
            .append(
                $("<div><div><label for='People_" + index + "__DOB'>DOB</label></div></div>").prepend(function () {
                    return $("<input id='People_" + index + "__DOB' name='People[" + index + "].DOB' title='Date of Birth' type='text' class='entry' maxlength='10' style='width: 75px' />")
                           .inputmask("mm/dd/yyyy", { placeholder: "MM/DD/YYYY" });
                })
            )
        )
        .append(function () {
            var $contactInfo = $(
                "<div class='field'>" +
                    "<div class='field' id='People_" + index + "__ContactInfo'" + (indexNum > 0 ? " style='display:none;'" : "") + ">" +
                        "<div>" +
                            "<input " + (indexNum > 0 ? "disabled='true' " : "") + "id='People_" + index + "__Email' data-index='" + index + "' name='People[" + index + "].Email' title='Email' type='text' class='email entry' maxlength='70' style='width: 530px' />" +
                            "<div><label for='People_" + index + "__Email'>Email</label></div>" +
                        "</div>" +
                        "<div>" +
                            "<input " + (indexNum > 0 ? "disabled='true' " : "") + "id='People_" + index + "__Phone' data-index='" + index + "' name='People[" + index + "].Phone' title='Phone Number' type='text' class='phone entry' maxlength='14' style='width: 100px' />" +
                            "<div><label for='People_" + index + "__Phone'>Phone #</label></div>" +
                        "</div>" +
                    "</div>" +
                "</div>"
            );

            if (indexNum > 0) {
                $contactInfo.append(
                    $(
                        "<div>" +
                            "<div>&nbsp;</div>" +
                            "<input id='People_" + index + "__UseContactInfo' type='checkbox' data-index='" + index + "' title='Use Email/Phone' class='useContactInfo' />" +
                            "<label for='People_" + index + "__UseContactInfo'>&nbsp;Add Email/Phone</label>" +
                        "</div>"
                    )
                );
            } else {
                $("#People_" + index + "__Phone", $contactInfo).inputmask("mask", { mask: "(999) 999-9999", placeholder: " " });
            }

            return $contactInfo;
        });
    }

    function AddRulesForPerson(panel) {
        $(".fname", panel).rules("add", {
            messages: { required: "First name is required for person" }
        });

        $(".lname", panel).rules("add", {
            messages: { required: "Last name is required for person" }
        });

        $(".email", panel).rules('add', {
            required: {
                depends: function () {
                    return IsInfoEmpty("Phone", $(this).data("index"));
                }
            },
            messages: { required: "Email is required for person" }
        });

        $(".phone", panel).rules('add', {
            required: {
                depends: function () {
                    return IsInfoEmpty("Email", $(this).data("index"));
                }
            },
            messages: { required: "Phone is required for person" }
        });
    }

    function RemRulesForPeople(panels) {
        panels && panels.each(function () { $(".fname, .lname, .email, .phone", $(this)).rules("remove"); });
    }

    function GetPet(cls, useMargins, index) {
        return $(
            "<div class='" + cls + "'" + (useMargins ? " style='margin-top: 10px; margin-bottom: 10px'" : "") + ">" +
                "<input type='hidden' name='Pets.Index' value='" + index + "' />" +
                "<div class='field'>" +
                    "<div>" +
                        "<input class='name entry required' id='Pets_" + index + "__Name' name='Pets[" + index + "].Name' title='Name' type='text' maxlength='30' style='width: 250px' />" +
                        "<div><label for='Pets_" + index + "__Name'>* Name</label></div>" +
                    "</div>" +
                    "<div>" +
                        "<input class='type entry required' id='Pets_" + index + "__Breed' name='Pets[" + index + "].Breed' title='Type/Breed' type='text' maxlength='50' style='width: 380px' />" +
                        "<div><label for='Pets_" + index + "__Breed'>* Type/Breed</label></div>" +
                    "</div>" +
                "</div>" +
                "<div class='field'>" +
                    "<div class='field'>" +
                        "<div>Friendly?</div>" +
                        "<div><label><input type='radio' name='Pets[" + index + "].IsFriendly' value='true' checked='checked' /> Yes</label></div>" +
                        "<div><label><input type='radio' name='Pets[" + index + "].IsFriendly' value='false' /> No</label></div>" +
                    "</div>" +
                    "<div class='field'>" +
                        "<div style='padding-left: 20px'>Normally stays</div>" +
                        "<div><label><input name='Pets[" + index + "].Location' type='checkbox' value='Inside' /> Inside</label></div>" +
                        "<div><label><input name='Pets[" + index + "].Location' type='checkbox' value='Outside' /> Outside</label></div>" +
                    "</div>" +
                "</div>" +
            "</div>"
        );
    }

    function AddRulesForPet(panel) {
        $(".name", panel).rules("add", {
            messages: { required: "Name is required for pet" }
        });

        $(".type", panel).rules("add", {
            messages: { required: "Type/Breed is required for pet" }
        });
    }

    function RemRulesForPets(panels) {
        panels && panels.each(function () { $(".name, .type", $(this)).rules("remove"); });
    }

    function RemoveItems(list, origTotal, newTotal, input, remRulesDelegate) {
        var diff = Math.abs(newTotal - origTotal);

        if (confirm("Are you sure you want to remove " + diff + (diff > 1 ? " items" : " item") + "?")) {
            var panels = list.children();

            remRulesDelegate(panels);

            panels.slice(newTotal).remove();
        } else {
            input.val(origTotal);
        }
    }

    function AddItems(list, origTotal, newTotal, getDelegate, addRulesDelegate) {
        for (var i = origTotal; i < newTotal; i++) {
            var panel = getDelegate("object" + ((i + 1) % 2 == 0 ? " altobject" : ""), origTotal == 1 || i > 1, "index_" + i, i);

            list.append(panel);

            addRulesDelegate(panel);
        }
    }

    function UpdateList(list, input, getDelegate, addRulesDelegate, remRulesDelegate) {
        // If the element doesn't exist exit the function
        if (!list || !list.length || input.val() == "") return;

        var total = list.children().length;
        var value = new Number(input.val());

        if (value == total) return;

        if (value - total < 0) {
            RemoveItems(list, total, value, input, remRulesDelegate);
        } else {
            AddItems(list, total, value, getDelegate, addRulesDelegate);
        }
    }
    
    function IsInfoEmpty(id, index)
    {
        var keyPref = "#People_" + index + "__";
        var $useContactInfoChkbox = $(keyPref + "UseContactInfo");

        return $(keyPref + id).val().length == 0 && (
            $useContactInfoChkbox.length == 0 || ($useContactInfoChkbox.length > 0 && $useContactInfoChkbox.is(":checked"))
        );
    }

    $.extend($.fn, {
        Assessment: function (options) {
            var opts = $.extend({
                numOfPeople: "",
                peopleContainer: "people",
                numOfPets: "",
                petsContainer: "pets"
            }, options);

            var people = $("#" + opts.peopleContainer).on("click", "input.useContactInfo", function () {
                var $chkbox = $(this);
                var isChecked = $chkbox.is(":checked");
                var prefix = "#People_" + $chkbox.data("index") + "__";
                var $phone = $(prefix + "Phone");
                var $email = $(prefix + "Email");
                var $contactInfo = $(prefix + "ContactInfo");

                $phone.prop('disabled', !isChecked);
                $email.prop('disabled', !isChecked);

                if (!isChecked) {
                    $contactInfo.hide();
                    $email.val("");
                    $phone.val("");
                    $phone.inputmask("remove");
                } else {
                    $phone.inputmask("mask", { mask: "(999) 999-9999", placeholder: " " });
                    $contactInfo.show();
                }
            });

            var pets = $("#" + opts.petsContainer);

            this.UpdatePeople = function (input) { UpdateList(people, input, GetPerson, AddRulesForPerson, RemRulesForPeople); };
            this.UpdatePets = function (input) { UpdateList(pets, input, GetPet, AddRulesForPet, RemRulesForPets); };

            $("input.tfaction").click(function () {
                var input = $(this);
                var div = $("div#" + input.attr("name").toLowerCase());
                if (div.length == 0) return;

                var isRadio = input.attr("type").toLowerCase() == "radio";

                if ((isRadio && input.val().toLowerCase() == "true") || (!isRadio && input.is(":checked"))) {
                    div.removeClass("hidden");
                    return;
                }

                div.addClass("hidden");
            });

            return this;
        }
    });
})(jQuery);

function InitializeNumericInputs(input, func, exec) {
    input.keyup(function () {
        var $this = $(this);
        var id = $this[0].id;
        clearTimeout($.data(this, id));
        $this.data(id, setTimeout(func($this), 1000));
    });

    if (exec) func(input);
}