const sucursalId = localStorage.getItem('sucursalId');

fetch(`https://localhost:7107/api/Parcial/GetSucursalById/${sucursalId}`)
    .then(response => response.json())
    .then(data => {
        document.getElementById('nombre').value = data.data.nombre;
        document.getElementById('ciudad').value = data.data.ciudad;
        document.getElementById('telefono').value = data.data.telefono;
        document.getElementById('nombreTitular').value = data.data.nombreTitular;
        document.getElementById('apellidoTitular').value = data.data.apellidoTitular;
    })
    .catch(error => console.error(error));

fetch('https://localhost:7107/api/Parcial/GetProvincias')
    .then(response => response.json())
    .then(data => {
        const provinciaSelect = document.getElementById('provincia');
        data.data.forEach(provincia => {
            const option = document.createElement('option');
            option.value = provincia.id;
            option.textContent = provincia.nombre;
            provinciaSelect.appendChild(option);
        });
    })
    .catch(error => console.error(error));

fetch('https://localhost:7107/api/Parcial/GetTipos')
    .then(response => response.json())
    .then(data => {
        const tipoSelect = document.getElementById('tipo');
        data.data.forEach(tipo => {
            const option = document.createElement('option');
            option.value = tipo.id;
            option.textContent = tipo.nombre;
            tipoSelect.appendChild(option);
        });
    })
    .catch(error => console.error(error));

document.getElementById('updateForm').addEventListener('submit', event => {
    event.preventDefault();

    const nombre = document.getElementById('nombre').value;
    const ciudad = document.getElementById('ciudad').value;
    const telefono = document.getElementById('telefono').value;
    const nombreTitular = document.getElementById('nombreTitular').value;
    const apellidoTitular = document.getElementById('apellidoTitular').value;
    const provinciaId = document.getElementById('provincia').value;
    const tipoId = document.getElementById('tipo').value;

    const bodyJson = {
        id: sucursalId,
        nombre: nombre,
        ciudad: ciudad,
        telefono: telefono,
        nombreTitular: nombreTitular,
        apellidoTitular: apellidoTitular,
        provinciaId: provinciaId,
        tipoId: tipoId
    };

    fetch('https://localhost:7107/api/Parcial/PutSucursal', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bodyJson)
    })
        .then(response => response.json())
        .then(data => {
            alert(data.message);
            window.location.href = 'TodasLasSucursales.html';
        })
        .catch(error => console.error(error));
});