

let app = new Vue({
    el: "#app",
    data: {
        objTipoM: {
            IdTipMan: '',
            Descripcion: ''
        },
        list: {
            TipoM: [],
            Id: []
        }
    },
    created: async function () {
        await this.ListTipoM();
    },
    mounted: async function () {
        this.$nextTick(() => {
            this.SetFocus();
        });
    },
    methods: {

        ListTipoM: async function () {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('TipoM/ListTipoM'))
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.TipoM = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo ListTipoM');
                });
        },


        DeleteTipoM: async function (e) {



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

            var codtm = data[0]
            //delete

            //swal
            Swal.fire({
                title: '¿Estas Seguro?',
                text: "Deseas eliminar este Tipo de Mantenimiento",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sì, Eliminar Tipo de Mantenimiento'
            }).then((result) => {
                if (result.value) {
                    //swal-end
                    axios.post(getBaseUrl.obtenerUrlAbsoluta("TipoM/DeleteTipoM"), { IdTipMan: codtm })
                        .then(res => {
                            if (res.data.Estado) {

                                Notifications.Messages.success("Registro Eliminado");
                                setTimeout(() => { this.$refs.frmTipoM.submit(); }, 1800);

                                console.log(res.data.Estado);
                                window.setTimeout(function () { location.reload() }, 2000)

                            } else if (res.data.tipoNotificacion) {

                                ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                            }
                            if (res.data.Estado == false) {
                                Notifications.Messages.warning("este Tipo de Mantenimiento tiene Tareas asignadas");
                            }

                        })
                    //fin delete    
                    //fin swal 1
                }


            })
            //fin swal2


        },

        SelectTipoM: async function (e) {

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

            //axios

            var codtm = data[0]
            var desctm = data[1]

            axios.post(getBaseUrl.obtenerUrlAbsoluta("TipoM/SelectTipoM"), { IdTipMan: codtm })
                .then(res => {
                    if (res.data.Estado) {

                        console.log(res.data.Valor.list)
                        document.getElementById('lblcodtipom').innerHTML = codtm;
                        document.getElementById('txtdesctipom').value = desctm;
                        $('html, body').animate({ scrollTop: 0 }, 'fast');

                        document.getElementById('lblEstadoC').innerHTML = "2";
                        $("#spaEstadoD").text("Editando registros");

                        document.getElementById("txtdesctipom").focus();

                        $('#btnGrabar').prop('disabled', false);



                        Notifications.Messages.success("Registro Cargado");


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
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('TipoM/IdTipoM'))
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Id = (res.data.Valor.List) ? res.data.Valor.List : [];
                        //asigna id maximo desde la bd
                        document.getElementById('lblcodtipom').innerHTML = _this.list.Id[0].IdTipMan;

                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo IdTipoM');
                });
            //fin get id
            //nuevo elemento
            document.getElementById('lblEstadoC').innerHTML = "1";
            $("#spaEstadoD").text("Agregando registros");
            document.getElementById('txtdesctipom').innerHTML = "";           
            document.getElementById('txtdesctipom').focus();
            $('#btnGrabar').prop('disabled', false);
        },

        Grabar: async function () {
            //codigo y sistema
            var codtm = document.getElementById("lblcodtipom").innerHTML;
            var desctm = document.getElementById("txtdesctipom").value;
            var coduser = document.getElementById("lblcodusuario").innerHTML;
            var fecha = new Date();
            var fechar = ""
            fechar = (fecha.getDate() + "/" + (fecha.getMonth() + 1) + "/" + fecha.getFullYear());

            if (desctm.length == 0) {
                console.log(desctm.length);
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
                        axios.post(getBaseUrl.obtenerUrlAbsoluta("TipoM/InsertTipoM"), {
                            IdTipMan: codtm, Descripcion: desctm, UsuarioRegistro: coduser, FechaRegistro: fechar
                        })
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
                        axios.post(getBaseUrl.obtenerUrlAbsoluta("TipoM/UpdateTipoM"), {
                            IdTipMan: codtm, Descripcion: desctm, Kilometros: 0,
                            KilometrosAviso: 0, Dias: 0,DiasAviso: 0, Horas: 0, HorasAviso: 0
                        })
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
        "objTipoM.IdTipMan": function (newval, oldval) {
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
    table = document.getElementById("tableTipoM");
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
    table = document.getElementById("tableTipoM");
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
