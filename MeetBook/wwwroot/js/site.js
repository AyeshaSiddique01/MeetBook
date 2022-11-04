// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getFile(filePath) {
    return filePath.substr(filePath.lastIndexOf('\\') + 1).split('.')[0] + ".png";
}
function getoutput() {
	filename.value = getFile(inputfile.value);
}
function showPassword() {
    var x = document.getElementById("pass");
    if (x.type == "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
function showPasswordC() {
    var x = document.getElementById("passC");
    if (x.type == "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
function confirmPassword() {
    var password = document.getElementById("pass").value;
    var passwordC = document.getElementById("passC").value;
    if (password != passwordC) {
        document.getElementById("messageError").innerHTML = "Password does not match<br />";
    } else {
        document.getElementById("messageError").innerHTML = "";
    }
}
function myValidation() {
    var password = document.getElementById("pass").value;
    var passwordC = document.getElementById("passC").value;
    if (password != passwordC) {
        return false;
    } else {
        return true;
    }
}
$(document).ready(function () {
    $(".like_btn").on('click', function () {
        var ID = $(this).attr('value'),
            likeCounter = $(this).closest('.card-footer').find('.like-counter'),
            url = $(this).find("#LikeImage");
        $.get("/Home/LikePost", { postId: ID }, function (result) {
            likeCounter.html(result[0]);
            if (result[1] == 1)
                url.attr("src", "/Background/heartfill.png");
            else
                url.attr("src", "/Background/heart.png");
        });
    });
    //$(".BlockAccount").click(function () {
    //    var ID = $(this).closest(".AccountRow").find('#AccountId').val,
    //        status = $(this).attr('value');
    //    alert(ID);
    //    $.post("/Admin/BlockAccount", { AccId: ID }, function (result) {
    //        status.html(result);
    //    });
    //});
	$("#searchUser").keyup(function () {
		var s = $("#searchUser").val();
		$.get("/Home/SearchpartialView", { searching: s }, function (result) {
			$("#searchlist").html(result);
		});
      });
	$("#email").keyup(function () {
		var s = $("#email").val();
		$.get("/Home/emailExist", { email: s }, function (result) {
			$("#emailExistDiv").html(result);
		});
	});
	$("#OldPassword").keyup(function () {
		var s = $("#OldPassword").val();
		$.get("/Home/PasswordValidate", { password: s }, function (result) {
			$("#IncorrectPassword").html(result);
		});
	});
	$("#PhoneNo").keyup(function () {
		var s = $("#PhoneNo").val();
		$.get("/Home/phoneExist", { phone: s }, function (result) {
			$("#phoneExistDiv").html(result);
		});
    });
	$('#searchUser').on('focus', function () {
		$('.dropdown-menu').show();
    });
    $('#Accounts').DataTable({})
    $('#Posts').DataTable({})
    $('#PostLikes').DataTable({})
});