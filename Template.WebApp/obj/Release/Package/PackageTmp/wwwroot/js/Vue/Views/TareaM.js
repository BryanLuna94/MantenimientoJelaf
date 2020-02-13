
 

let app = new Vue({
    el: "#app",
    data: {
        objTareaM: {
            IdTarea: '',
            Descripcion: '',
            IdTipMan:'',
            ID_tb_Sistema_Mant: '',
            ID_tb_SubSistema_Mant: ''
            
        },

        objSistemas: {
            Codigo: '',
            Descripcion: ''
        },
        objSistemas2: {
            Codigo: '',
            Descripcion: ''
        },
        objSubSistemas: {
            Codigo: '',
            Descripcion: ''
        },
        objSubSistemas2: {
            Codigo: '',
            Descripcion: ''
        },
        objTipoM: {
            Codigo: '',
            Descripcion: ''
        },
        objTipoM2: {
            Codigo: '',
            Descripcion: ''
        },
        list: {
            TareaM: [],
            TipoM: [],
            TipoM2: [],
            Sistemas: [],
            Sistemas2: [],
            SubSistemas: [],
            SubSistemas2: [],
            Id: []
        }
    },
    created: async function () {
        await this.ListTareaM();
        await this.getTipoM("");
        await this.getSistemas("");
        await this.getSubSistemas("");
        await this.getTipoM2("");
        await this.getSistemas2("");
        await this.getSubSistemas2("");
    },
    mounted: async function () {
        this.$nextTick(() => {
            this.SetFocus();
        });
    },
    methods: {

        getTipoM: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListTipoMAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.TipoM = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getTipoM');
                });
        },

        getTipoM2: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListTipoMAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.TipoM2 = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getTipoM2');
                });
        },

        SelFiltro3: async function (value) {

            document.getElementById("TxtFiltro3").value = value;

            // Declare variables

            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("TxtFiltro3");
            filter = input.value.toUpperCase();
            table = document.getElementById("tableTareaM");
            tr = table.getElementsByTagName("tr");

            // Loop through all table rows, and hide those who don't match the search query
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[2];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    //filtro exacto para combobox
                    if (txtValue.toUpperCase().indexOf(filter) > -1 && td.innerText == value) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        },
        getSistemas: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListSistemasAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Sistemas = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getSistemas');
                });
        },
        getSistemas2: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListSistemasAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Sistemas2 = (res.data.Valor.List) ? res.data.Valor.List : [];

                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getSistemas');
                });
        },



        SelFiltro4: async function (value) {
          
            document.getElementById("TxtFiltro4").value = value;

            // Declare variables

            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("TxtFiltro4");
            filter = input.value.toUpperCase();
            table = document.getElementById("tableTareaM");
            tr = table.getElementsByTagName("tr");

            // Loop through all table rows, and hide those who don't match the search query
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[3];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    //filtro exacto para combobox
                    if (txtValue.toUpperCase().indexOf(filter) > -1 && td.innerText == value) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        },

        getSubSistemas: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListSubSistemasAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.SubSistemas = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getSistemas');
                });
        },

        getSubSistemas2: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListSubSistemasAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.SubSistemas2 = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getSistemas');
                });
        },

        SelFiltro5: async function (value) {

            document.getElementById("TxtFiltro5").value = value;

            // Declare variables

            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("TxtFiltro5");
            filter = input.value.toUpperCase();
            table = document.getElementById("tableTareaM");
            tr = table.getElementsByTagName("tr");

            // Loop through all table rows, and hide those who don't match the search query
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[4];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    //filtro exacto para combobox
                    if (txtValue.toUpperCase().indexOf(filter) > -1 && td.innerText == value) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        },

        ListTareaM: async function () {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('TareaM/ListTareaM'))
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.TareaM = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo ListTareaM');
                });
        },


        DeleteTareaM: async function (e) {



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
                    axios.post(getBaseUrl.obtenerUrlAbsoluta("TareaM/DeleteTareaM"), { IdTarea: codtm })
                        .then(res => {
                            if (res.data.Estado) {

                                Notifications.Messages.success("Registro Eliminado");
                                setTimeout(() => { this.$refs.frmTareaM.submit(); }, 1800);

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

        SelectTareaM: async function (e) {

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
            var codtipom = data[2]
            var codsis = data[3]
            var codsub = data[4]

            axios.post(getBaseUrl.obtenerUrlAbsoluta("TareaM/SelectTareaM"), { IdTarea: codtm })
                .then(res => {
                    if (res.data.Estado) {

                        console.log(res.data.Valor.list)
                        document.getElementById('lblcodTareaM').innerHTML = codtm;
                        document.getElementById('txtdescTareaM').value = desctm;
                        this.$refs.txtCodTipoM.value = codtipom;
                        this.$refs.txtCodSistema.value = codsis;
                        this.$refs.txtCodSubSistema.value = codsub;


                        $('html, body').animate({ scrollTop: 0 }, 'fast');

                        document.getElementById('lblEstadoC').innerHTML = "2";
                        $("#spaEstadoD").text("Editando registros");

                        document.getElementById("txtdescTareaM").focus();

                        $('#btnGrabar').prop('disabled', false);



                        Notifications.Messages.success("Registro Cargado");


                    } else if (res.data.tipoNotificacion) {
                        ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                    }

                })
            //DESACTIVA Div SubSistemas y su contenido
            var nodes = document.getElementById("DivTipoM").getElementsByTagName('*');
            for (var i = 0; i < nodes.length; i++) {
                nodes[i].disabled = true;
            }
            //fin DESACTIVA Div SubSistemas y su contenido

        },

        Cancelar: function () {
            window.setTimeout(function () { location.reload() }, 50)
        },

        Nuevo: async function () {


            //get id axios
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('TareaM/IdTareaM'))
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Id = (res.data.Valor.List) ? res.data.Valor.List : [];
                        //asigna id maximo desde la bd
                        document.getElementById('lblcodTareaM').innerHTML = _this.list.Id[0].IdTarea;

                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo IdTareaM');
                });
            //fin get id
            //nuevo elemento
            document.getElementById('lblEstadoC').innerHTML = "1";
            $("#spaEstadoD").text("Agregando registros");
            document.getElementById('txtdescTareaM').innerHTML = "";           
            document.getElementById('txtdescTareaM').focus();
            $('#btnGrabar').prop('disabled', false);

        },

        Grabar: async function () {
            //codigo y sistema
            var codtm = document.getElementById("lblcodTareaM").innerHTML;
            var desctm = document.getElementById("txtdescTareaM").value;
            var coduser = document.getElementById("lblcodusuario").innerHTML;
            var codtipom = this.objTipoM.IdTipMan;
            var codsis = this.objSistemas.ID_tb_Sistema_Mant;
            var codsub = this.objSubSistemas.ID_tb_SubSistema_Mant;
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
                        axios.post(getBaseUrl.obtenerUrlAbsoluta("TareaM/InsertTareaM"), {
                            IdTarea: codtm, IdTipMan: codtipom, Descripcion: desctm, UsuarioRegistro: coduser, FechaRegistro: fechar, ID_tb_Sistema_Mant: codsis, ID_tb_SubSistema_Mant: codsub
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
                        axios.post(getBaseUrl.obtenerUrlAbsoluta("TareaM/UpdateTareaM"), {
                            IdTarea: codtm, IdTipMan: codtipom, Descripcion: desctm, ID_tb_Sistema_Mant: codsis, ID_tb_SubSistema_Mant: codsub
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
        "objTareaM.IdTarea": function (newval, oldval) {
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
    table = document.getElementById("tableTareaM");
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
    table = document.getElementById("tableTareaM");
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


