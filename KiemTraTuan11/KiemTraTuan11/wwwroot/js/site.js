// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#create-file').click((e) => {

    let fileName = document.querySelector('#fileName').value;
    let folderId = document.querySelector('#folder-id').value;
    let url = "../../api/File/PostFileModel";

    if (folderId == "0") {
        alert("Can not create file in Root !");
        return;
    }

    fetch(url,
        {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "Id": 0,
                "FileName": fileName,
                "FolderId": parseInt(folderId),
                "Status": true

            })
        })
        .then(response => response.json())
        .then(responseAsJson => {
            location.reload();
            console.log(responseAsJson);
        })
        .catch(err => console.log(err));

});

$('#create-folder').click((e) => {

    let folderName = document.querySelector('#folderName').value;
    let folderId = document.querySelector('#parent-id').value;
    let url = "../../api/Folder/PostFolderModel";

 
    fetch(url,
        {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "Id": 0,
                "FolderName": folderName,
                "ParentsId": parseInt(folderId),
                "Status": true

            })
        })
        .then(response => response.json())
        .then(responseAsJson => {
            location.reload();
            console.log(responseAsJson);
        })
        .catch(err => console.log(err));

});

//Delete
var delFolder = new Set();
var delFile = new Set();

function selectedItem(node, list) {
    node.classList.toggle("active");
    if (node.classList.contains('active')) {
        list.add(node.id);
    }
    else { list.delete(node.id) }
    console.log(list);
}
var delItems = document.querySelectorAll('.del-item');
delItems.forEach(element => {
    element.addEventListener('click', function (e) {
        console.log(this.getAttribute("type"));
        if (this.getAttribute('type') == 'folder') {
            selectedItem(this, delFolder);
        }
        if (this.getAttribute('type') == 'file') {
            selectedItem(this, delFile);
        }
    })
});

$('#delete-file-folder').click((e) => {

    delFile.forEach(id => {
        let getFileUrl = `../../api/File/GetFileModel/${id}`;
        let putFileUrl = `../../api/File/PutFileModel/${id}`;

        fetch(getFileUrl)
            .then(respone => respone.json())
            .then(responeJson => {
                console.log(responeJson);
                fetch(putFileUrl,
                    {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(
                            {
                                "Id": responeJson.id,
                                "FileName": responeJson.fileName,
                                "FolderId": responeJson.folderId,
                                "Status": false,
                            }
                        )
                    }
                )
                    .then(respone => respone.json())
                    .then(responeJson => location.reload())
                    .catch(err => location.reload());
            })
            .catch(err => console.log(err));
    });

    delFolder.forEach(id => {
        let getFolderUrl = `../../api/Folder/GetFolderModel/${id}`;
        let putFolderUrl = `../../api/Folder/PutFolderModel/${id}`;
        fetch(getFolderUrl)
            .then(respone => respone.json())
            .then(responeJson => {
                console.log(responeJson);

                fetch(putFolderUrl,
                    {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(
                            {
                                "Id": responeJson.id,
                                "FolderName": responeJson.folderName,
                                "ParentsId": responeJson.parentsId,
                                "Status": false,
                            }
                        )
                    }
                )
                    .then(respone => respone.json())
                    .then(responeJson => location.reload())
                    .catch(err => location.reload());
            })
            .catch(err => console.log(err));
    });
});

$('#fdelete').click((e) => {
    delFile.forEach(id => {
        let url = `../../api/file/deletefilemodel/${id}`;
        fetch(url, { method: 'DELETE' })
            .then(respone => respone.json())
            .then(responeJson => location.reload())
            .catch(err => console.log(err));
    });

    delFolder.forEach(id => {
        let url = `../../api/folder/deletefoldermodel/${id}`;

        fetch(url, {
            method: 'DELETE'
        })
            .then(respone => respone.json())
            .then(responeJson => location.reload())
            .catch(err => console.log(err));
    });

});

