const uri = 'api/Accounts';
let accounts = [];

function getAccounts() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayAccounts(data))
        .catch(error => console.error('Unable to get Accounts.', error));
}

function addAccount() {
    const addNameTextbox = document.getElementById('add-name');
    const addDetailsTextbox = document.getElementById('add-paymentdetails');

    const account = {
        Name: addNameTextbox.value.trim(),
        PaymentDetails: addDetailsTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(account)
    })
        .then(response => response.json())
        .then(() => {
            getAccounts();
            addNameTextbox.value = '';
            addDetailsTextbox.value = '';
        })
        .catch(error => console.error('Unable to add Account.', error));
}

function deleteAccount(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getAccounts())
        .catch(error => console.error('Unable to delete Account.', error));
}

function displayEditForm(id) {
    const account = accounts.find(account => account.id === id);

    document.getElementById('edit-id').value = account.id;
    document.getElementById('edit-name').value = account.name;
    document.getElementById('edit-paymentdetails').value = account.paymentDetails;
    document.getElementById('editForm').style.display = 'block';
}

function updateAccount() {
    const accountId = document.getElementById('edit-id').value;
    const account = {
        id: parseInt(accountId, 10),
        Name: document.getElementById('edit-name').value.trim(),
        PaymentDetails: document.getElementById('edit-paymentdetails').value.trim()
    };

    fetch(`${uri}/${accountId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(account)
    })
        .then(() => getAccounts())
        .catch(error => console.error('Unable to update account.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayAccounts(data) {
    const tBody = document.getElementById('accounts');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(account => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${account.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteAccount(${account.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(account.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(account.paymentDetails);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    accounts = data;
}
