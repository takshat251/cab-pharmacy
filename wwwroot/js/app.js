
async function fetchMedicines(query = '') {
    const response = await fetch(`/api/medicines?search=${query}`);
    const medicines = await response.json();
    const tbody = document.querySelector('#medicineTable tbody');
    tbody.innerHTML = '';

    medicines.forEach(med => {
        const tr = document.createElement('tr');
        const now = new Date();
        const expiry = new Date(med.expiryDate);

        if ((expiry - now) / (1000 * 60 * 60 * 24) < 30) {
            tr.classList.add('expiring');
        } else if (med.quantity < 10) {
            tr.classList.add('low-stock');
        }

        tr.innerHTML = `
            <td>${med.fullName}</td>
            <td>${new Date(med.expiryDate).toLocaleDateString()}</td>
            <td>${med.quantity}</td>
            <td>${med.price.toFixed(2)}</td>
            <td>${med.brand}</td>
            <td>
                <button onclick="editMedicine('${med.id}')">Edit</button>
                <button onclick="deleteMedicine('${med.id}')">Delete</button>
            </td>
        `;
        tbody.appendChild(tr);
    });
}

function searchMedicines() {
    const query = document.getElementById('search').value;
    fetchMedicines(query);
}

window.onload = () => fetchMedicines();
