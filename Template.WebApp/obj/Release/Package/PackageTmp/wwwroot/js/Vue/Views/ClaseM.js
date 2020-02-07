


let app = new Vue({
        el: "#app",
            data:  {
        objClaseM: {
        IdClaseMantenimiento: '',
                    Descripcion: '',
                    NroOrden: ''
},
                list: {
                    ClaseM: []
}
},
            created: async function () {
                await this.ListClaseM();
    },
            mounted: async function () {
        this.$nextTick(() => {
            this.SetFocus();
        });
    },
methods: {

    ListClaseM: async function () {

        
        let _this = this;
        await axios.get(getBaseUrl.obtenerUrlAbsoluta('ClaseM/ListClaseM'))
                        .then(res => {
                            if (res.data.Estado) {
                                _this.list.ClaseM = (res.data.Valor.List) ? res.data.Valor.List : [];}
                        }).catch(error => {
                            Notifications.Messages.error('Ocurrió una excepción en el metodo ListClaseM');
    });
     },

    SelectClaseM: async function (e) {

        //extraer datos tabla


        e = e || window.event;
        var data = [];
        var target = e.srcElement || e.target;
        while (target && target.nodeName !== "TR") {
            target = target.parentNode;
        }
        if (target) {
            var cells = target.getElementsByTagName("td");
            for (var i = 0; i < cells.length; i++) {
                data.push(cells[i].innerHTML);
            }
        }

        //Listar ClaseM para editar

        var codcla = data[0]
        var descla = data[1]
        var nrocla = data[2]
        console.log(codcla);

        axios.post(getBaseUrl.obtenerUrlAbsoluta("ClaseM/SelectClaseM"), { IdClaseMantenimiento: codcla })
            .then(res => {
                if (res.data.Estado) {

                    console.log(codcla);
                    document.getElementById("txtCodClaseM").value = codcla;
                    document.getElementById("txtDescClaseM").value = descla;
                    document.getElementById("txtOrdClaseM").value = nrocla;

                    $('#txtCodClaseM').prop('disabled', true);
                    $('#txtDescClaseM').prop('disabled', false);
                    $('#txtOrdClaseM').prop('disabled', false);

                    $('html, body').animate({ scrollTop: 0 }, 'fast');

                    document.getElementById("lblEstadoC").innerHTML = "2";
                    $("#spaEstadoD").text("Editando registros");

                    document.getElementById("txtCodClaseM").focus();

                    $('#btnGrabar').prop('disabled', false);

                    Notifications.Messages.success("Registro Cargado");
                    setTimeout(() => { this.$refs.frmClaseM.submit(); }, 1800);


                } else if (res.data.tipoNotificacion) {
                    ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                }

            })


    },

    DelClaseM: async function (e) {
 
        //vars
            e = e || window.event;
            var data = [];
            var target = e.srcElement || e.target;
            while (target && target.nodeName !== "TR") {
                target = target.parentNode;
            }
            if (target) {
                var cells = target.getElementsByTagName("td");
                for (var i = 0; i < cells.length; i++) {
                    data.push(cells[i].innerHTML);
                }
            }
            //axios
                        var codcla = data[0]     
            //delete
        //swal
        Swal.fire({
            title: '¿Estas Seguro?',
            text: "Deseas Eliminar esta Clase",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sì, Eliminar Clase'
        }).then((result) => {
            if (result.value) {
                    //swal-end
            axios.post(getBaseUrl.obtenerUrlAbsoluta("ClaseM/DeleteClaseM"), { IdClaseMantenimiento: codcla })
                .then(res => {
                    if (res.data.Estado) {

                        Notifications.Messages.success("Registro Eliminado");
                        setTimeout(() => { this.$refs.frmClaseM.submit(); }, 1800);

                        console.log(res.data.Estado);
                        window.setTimeout(function () { location.reload() }, 2000)   
                     
                    } else if (res.data.tipoNotificacion) {
                        
                        ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                    }
                    if (res.data.Estado == false)
                    {
                        Notifications.Messages.warning("este Clase tiene Tipos de mantenimiento asignados");
                    }

                })
            //fin delete    
                //fin swal 1
            }

        
        })
        //fin swal2

     },


    Cancelar: function () {
        window.setTimeout(function () { location.reload() }, 50)   
    },

    Nuevo: async function () {
         
 
         //nuevo elemento
         document.getElementById('lblEstadoC').innerHTML = "1";
        $("#spaEstadoD").text("Agregando registros");
        document.getElementById("txtCodClaseM").value = "";
        $('#txtCodClaseM').prop('disabled', false);
        document.getElementById("txtDescClaseM").value="";
        $('#txtDescClaseM').prop('disabled', false);
        document.getElementById("txtOrdClaseM").value = "";
        $('#txtOrdClaseM').prop('disabled', false);
        document.getElementById("txtCodClaseM").focus();
         $('#btnGrabar').prop('disabled', false);    
    },

    Grabar: async function () {
        //codigo y ClaseM
        //codigo y sistema
        var codcla = document.getElementById("txtCodClaseM").value;
        var descla = document.getElementById("txtDescClaseM").value;
        var ordcla = document.getElementById("txtOrdClaseM").value;

        if (descla.length == 0 || ordcla.length == 0 ) {
            console.log(descsis.length);
            Notifications.Messages.warning("Llene todos los campos necesarios");
            return
        }

        //swal
        Swal.fire({
            title: '¿Estas Seguro?',
            text: "Deseas grabar esta Clase",
            type: 'info',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sì, Grabar Clase'
        }).then((result) => {
            if (result.value) {
                    //swal-end

            if (document.getElementById('lblEstadoC').innerHTML == "1") {
                //nuevo
                axios.post(getBaseUrl.obtenerUrlAbsoluta("ClaseM/InsertClaseM"), { IdClaseMantenimiento: codcla, Descripcion: descla, NroOrden: ordcla })
                    .then(res => {
                        if (res.data.Estado) {
                            console.log(res.data.Valor.Estado)
                            Notifications.Messages.success("Registro Guardado");
                            setTimeout(() => { this.$refs.frmClaseM.submit(); }, 1800);
                            window.setTimeout(function () { location.reload() }, 2000)   

                        } else if (res.data.tipoNotificacion) {
                            ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                        }
                    }) 
            }
           
            else {
                 //modificacion
                axios.post(getBaseUrl.obtenerUrlAbsoluta("ClaseM/UpdateClaseM"), { IdClaseMantenimiento: codcla, Descripcion: descla, NroOrden: ordcla  })
                    .then(res => {
                        if (res.data.Estado) {

                            console.log(res.data.Valor.Estado)


                            Notifications.Messages.success("Registro Actualizado");
                            setTimeout(() => { this.$refs.frmClaseM.submit(); }, 1800);
                            window.setTimeout(function () { location.reload() }, 2000)

                        } else if (res.data.tipoNotificacion) {
                            ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                        }
                    })
            }
 
                //fin swal 1
            }

        })
   
        //fin swal2
    },

},


            computed: {
        FullFields: function () {
                    return this.validateForm();
}
},
            watch: {
        "objClaseM.IdClaseMantenimiento": function (newval, oldval) {
                    if (newval) {
        this.SetFocus();
    }
}
}
});




//filtros

        function Filtrar1() {
            // Declare variables
            var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("TxtFiltro1");
    filter = input.value.toUpperCase();
    table = document.getElementById("tableClaseM");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
            for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
    if (td) {
        txtValue = td.textContent || td.innerText;
    if (txtValue.toUpperCase().indexOf(filter) > -1) {
        tr[i].style.display = "";
    } else {
        tr[i].style.display = "none";
    }
}
}
}
        function Filtrar2() {
            // Declare variables
            var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("TxtFiltro2");
    filter = input.value.toUpperCase();
    table = document.getElementById("tableClaseM");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
            for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
    if (td) {
        txtValue = td.textContent || td.innerText;
    if (txtValue.toUpperCase().indexOf(filter) > -1) {
        tr[i].style.display = "";
    } else {
        tr[i].style.display = "none";
    }
}
}
}
  