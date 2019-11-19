
function subscribeOn(userId) {
    $.ajax({
        type: "POST",
        url: "/Subscriptions/Subscribe/",
        data: JSON.stringify(userId),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });
}

function createDialogue(user1Id, user2Id) {
    let users = [ user1Id, user2Id ];
    let dialogueId;
    $.ajax({
        type: "POST",
        url: "/Conversations/CreateDialogue/",
        data: JSON.stringify(users),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            alert(data);
            dialogueId = data;
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });

    return dialogueId;
}

function writeToFriend(dialogueId, friendId, userId) {
    alert(dialogueId);
    if (dialogueId === "") {
        alert("dialogueId == ")
        dialogueId = createDialogue(friendId, userId);
        alert("new Dialoge id : " + dialogueId);
    }
    window.location.replace("/Conversations/Dialogue/" + dialogueId);
};