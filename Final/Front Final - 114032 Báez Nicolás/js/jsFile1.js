fetch('https://localhost:7107/api/Parcial/GetAllSucursales')
    .then(response => response.json())
    .then(data => {
        const list = document.querySelector('.ListaL');
        data.data.forEach(sucursal => {
            const listItem = document.createElement('li');
            listItem.classList.add('list-group-item');
            listItem.innerHTML = `
            <div class="row">
                <div class="col">${sucursal.nombre}</div>
                <div class="col">${sucursal.ciudad}</div>
                <div class="col">${sucursal.provinciaNombre}</div>
                <div class="col">${sucursal.tipoNombre}</div>
                <div class="col">${sucursal.nombreTitular}</div>
                <div class="col">${sucursal.apellidoTitular}</div>
                <div class="col">
                    <button class="btn btn-primary" onclick="saveIdAndRedirect('${sucursal.id}')">Actualizar</button>
                </div>
            </div>
        `;
            list.appendChild(listItem);
        });
    });

function saveIdAndRedirect(id) {
    localStorage.setItem('sucursalId', id);
    window.location.href = 'ActualizarSucursal.html';

}