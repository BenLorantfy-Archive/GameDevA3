var blocks = ["ground","ground","blank","ground"];


function renderBlocks(){
    for(var i = 0; i < blocks.length; i++){
        var template = $("#" + blocks[i] + "Template").html();
        var el = $(template);
        $("#map").append(el);
        el.css("left",i * 200);
        
    }
}

renderBlocks();

//    var ip = prompt("Please enter IP of computer running the Unity Game");
//    var port = prompt("Please enter port server is running on");
//    
var ip = "192.168.0.25";
var port = "8989";


// [ Create socket ]
var socket = new WebSocket("ws://" + ip + ":" + port);
socket.onmessage = function(event){
    var json = event.data;
    var data = JSON.parse(json);
    
    if(data.event == "movement"){
        $("#map").css({
             "left":data.x * 50 + 10
            ,"top":data.y * 50 - 30
        });     
    }else if(data.event == "chat"){
        $("#chatLog").append("<div class='comment'>" + data.message + "</div>")
    }else if(data.event == "platform"){
        var platform = $(".platform").eq(data.i);
        if(platform.length == 0){
            platform = $("<div class='platform'></div>");
            $("#map").append(platform);
        }
        
        platform.css({
             "left":data.x * -50 - 20
            ,"top":data.y * -50 + 50
        })
    }
}

$("#chatTextBox").keydown(function(e){

    if(e.keyCode == 13){
        var text = $(this).val();
        var data = {
             "event":"chat"  
            ,"message":text
        };
        socket.send(JSON.stringify(data));
        
        $(this).val("");
    } 
});

$(".ability").click(function(){
    var kind = $(this).val();
    var data = {
         "event":"vote"
        ,"kind":kind  
    };
    socket.send(JSON.stringify(data));
})

//send.onclick = function(){
//    var msg = textbox.value;
//    socket.send(msg);
//}