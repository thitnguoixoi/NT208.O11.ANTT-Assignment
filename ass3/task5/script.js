$("#validation-form").validate({
    rules:{
        name:{
            minlength: 4
        },
        phone:{
            number:true,
            minlength: 10,
            maxlength: 10
        },
        email:{
            email:true
        },
        password:{
            minlength: 5
        },
        repassword:{
            minlength:5,
            equalTo:'#password'
        }
    },
    messages:{
        name:{
            required: "Vui lòng nhập tên đăng nhập",
            minlength: "Tên đăng nhập phải lớn hơn 4 kí tự"
        },
        phone:{
            required: "Vui lòng nhập số điện thoại",
            number: "Vui lòng nhập số điện thoại hợp lệ",
            minlength: "Số điện thoại bạn vừa nhập không tồn tại",
            maxlength: "Số điện thoại bạn vừa nhập không tồn tại"
        },
        email:{
            required: "Vui lòng nhập Email",
            email: "Vui lòng nhập Email theo đúng định dạng"
        },
        password:{
            required: "Vui lòng nhập mật khẩu",
            minlength: "Mật khẩu cần có tối thiểu 5 kí tự"
        },
        repassword:{
            required: "Vui lòng nhập lại mật khẩu",
            equalTo: "Mật khẩu không trùng"
        }
    },

    submitHandler: function(form) {
      form.submit();
    }
});