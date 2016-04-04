var Project = {};
Project.Form = {};

//Retorna uma mensagem com estilo
var Message = {
    Render: function (message, style, isDispensable) {
        var button = '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>';
        $('#project-message').empty();
        if (isDispensable) {
            $('#project-message').append(button);
        }
        $('#project-message').attr('class', 'alert alert-' + style).append(message);
    },
    Success: function (message, isDispensable) {
        Message.Render(Message.Send(message), 'success', isDispensable);
    },
    Warning: function (message, isDispensable) {
        Message.Render(Message.Send(message), 'warning', isDispensable);
    },
    Information: function (message, isDispensable) {
        Message.Render(Message.Send(message), 'info', isDispensable);
    },
    Error: function (message, isDispensable) {
        Message.Render(Message.Send(message), 'danger', isDispensable);
    },
    Send: function (message) {
        if ($.isArray(message)) {
            var text = "";
            for (var i = 0; i < message.length; i++) {
                text += '<p>' + message[i] + '<p>';
            }
            return text;
        }
        return '<p>' + message + '<p>';
    }
};

//Preenche um formulário em relação aos atributos de um view-model.
Project.Form.Fill = function (id, viewModel) {
    $('#' + id).find(':input').each(function () {
        var input = $(this);
        $.each(viewModel, function (key, value) {
            if (input.attr('name') === key) {
                input.val(value);
            }
        });
    });
}