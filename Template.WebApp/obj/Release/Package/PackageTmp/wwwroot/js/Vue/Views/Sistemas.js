
    let app = new Vue({
        el: "#app",
            data: {
                objSistemas: {
                ID_tb_Sistema_Mant: '',
                Descripcion: ''
                },
                list: {
                    Sistemas: [],
                    Id: []
}
},
            created: async function () {
        await this.getSistemas();
    },
            mounted: async function () {
        this.$nextTick(() => {
            this.SetFocus();
        });
    },
methods: {

    getSistemas: async function () {
        let _this = this;
    await axios.get(getBaseUrl.obtenerUrlAbsoluta('Sistemas/SelectSistemas'))
                        .then(res => {
                            if (res.data.Estado) {
                                _this.list.Sistemas = (res.data.Valor.List) ? res.data.Valor.List : [];
                           
 
    }
                        }).catch(error => {
        Notifications.Messages.error('Ocurrió una excepción en el metodo getSistemas');
    });
     },


    DelSistema: async function (e) {



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

            var codsis = data[0]
            //delete

        //swal
        Swal.fire({
            title: '¿Estas Seguro?',
            text: "Deseas eliminar este Sistema",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sì, Eliminar Sistema'
        }).then((result) => {
            if (result.value) {
                    //swal-end

            axios.post(getBaseUrl.obtenerUrlAbsoluta("Sistemas/DeleteSistemas"), { ID_tb_Sistema_Mant: codsis })
                .then(res => {
                    if (res.data.Estado) {

                        Notifications.Messages.success("Registro Eliminado");
                        setTimeout(() => { this.$refs.frmSistemas.submit(); }, 1800);

                        console.log(res.data.Estado);
                        window.setTimeout(function () { location.reload() }, 2000)   
                     
                    } else if (res.data.tipoNotificacion) {
                        
                        ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                    }
                    if (res.data.Estado == false)
                    {
                        Notifications.Messages.warning("este Sistema tiene subsistemas asignados");
                    }

                })
            //fin delete    
                //fin swal 1
            }

            
        })
        //fin swal2


     },

     ListSistema: async function (e) {
 
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

             //Listar sistema para editar

             var codsis = data[0]
             var descsis = data[1]
             
             axios.post(getBaseUrl.obtenerUrlAbsoluta("Sistemas/ListSistemas"), { ID_tb_Sistema_Mant: codsis })
                 .then(res => {
                     if (res.data.Estado) {
 
                         console.log(res.data.Valor.list)
                         document.getElementById('lblCodSistema').innerHTML = codsis;
                         document.getElementById('txtDescSistema').value = descsis;
                         $('html, body').animate({ scrollTop: 0 }, 'fast');
                     
                         document.getElementById('lblEstadoC').innerHTML = "2";
                         $("#spaEstadoD").text("Editando registros");

                         document.getElementById("txtDescSistema").focus();

                         $('#btnGrabar').prop('disabled', false);

                      
 
                         Notifications.Messages.success("Registro Cargado");
                         setTimeout(() => { this.$refs.frmSistemas.submit(); }, 1800);


                     } else if (res.data.tipoNotificacion) {
                         ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                     }

                 })
    

    },

    Cancelar: function () {
        window.setTimeout(function () { location.reload() }, 50)   
    },

    Nuevo: async function () {
         
 
         //get id axios
         let _this = this;
         await axios.get(getBaseUrl.obtenerUrlAbsoluta('Sistemas/IdSistemas'))
             .then(res => {
                 if (res.data.Estado) {
                     _this.list.Id = (res.data.Valor.List) ? res.data.Valor.List : [];
                     //asigna id maximo desde la bd
                     document.getElementById('lblCodSistema').innerHTML = _this.list.Id[0].ID_tb_Sistema_Mant;
               
                 }
             }).catch(error => {
                 Notifications.Messages.error('Ocurrió una excepción en el metodo IdSistemas');
             });
             //fin get id
         //nuevo elemento
         document.getElementById('lblEstadoC').innerHTML = "1";
         $("#spaEstadoD").text("Agregando registros");
        document.getElementById('txtDescSistema').innerHTML="";
         document.getElementById('txtDescSistema').focus();

         $('#btnGrabar').prop('disabled', false);    
    },

    Grabar: async function () {
        //codigo y sistema
        var codsis = document.getElementById("lblCodSistema").innerHTML;
        var descsis = document.getElementById("txtDescSistema").value;

        if (descsis.length == 0) {
            console.log(descsis.length);
            Notifications.Messages.warning("Ingrese una descripción");

            return
        }
        //swal
        Swal.fire({
            title: '¿Estas Seguro?',
            text: "Deseas grabar este Sistema",
            type: 'info',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sì, Grabar Sistema'
        }).then((result) => {
            if (result.value) {
                    //swal-end

            if (document.getElementById('lblEstadoC').innerHTML == "1") {

                //nuevo
                axios.post(getBaseUrl.obtenerUrlAbsoluta("Sistemas/InsertSistemas"), { ID_tb_Sistema_Mant: codsis,Descripcion: descsis })
                    .then(res => {
                        if (res.data.Estado) {
                            Notifications.Messages.success("Registro Guardado");
                            window.setTimeout(function () { location.reload() }, 2000)   
                        } else if (res.data.tipoNotificacion) {
                            ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                        }
                    })
            }
           
            else if (document.getElementById('lblEstadoC').innerHTML == "2") {
                 //modificacion
                axios.post(getBaseUrl.obtenerUrlAbsoluta("Sistemas/UpdateSistemas"), { ID_tb_Sistema_Mant: codsis, Descripcion: descsis })
                    .then(res => {
                        if (res.data.Estado) {
                            Notifications.Messages.success("Registro Actualizado");
                            window.setTimeout(function () { location.reload() }, 2000)
                        } else if (res.data.tipoNotificacion) {
                            ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                        }
                    })
                }
            }
                //fin swal 1
        },

        )   
   }
        //fin swal2
   
 
},


            computed: {
        FullFields: function () {
                    return this.validateForm();
}
},
            watch: {
        "objSistemas.ID_tb_Sistema_Mant": function (newval, oldval) {
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
    table = document.getElementById("tableSistema");
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
    table = document.getElementById("tableSistema");
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
  