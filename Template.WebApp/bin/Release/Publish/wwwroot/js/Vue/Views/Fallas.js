
 

let app = new Vue({
    el: "#app",
    data: {
        objFallasD: {
            IdSolicitudRevisionD: '',
            IdSolicitudRevision: '',
            Observacion:'',
            UsuarioRegistro: '',
            Fecharegistro: '',
            HoraRegistro: '',
            Estado: '',
            IdSistema: '',
            IdObservacion:''
            
        },
        objTipoM: {
            Codigo: '',
            Descripcion: ''
        },
        list: {
            FallasD: [],
            TipoM: [],
            Id: []
        }
    },
    created: async function () {
        await this.SelectFallasD();
        await this.getTipoM("");
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
        SelectFallasD: async function () {
            let _this = this;
            Id = document.getElementById("IdSolicitudRevision").innerHTML;
            
            axios.post(getBaseUrl.obtenerUrlAbsoluta("Fallas/SelectFallasD"), { ID: Id })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.FallasD = (res.data.Valor.List) ? res.data.Valor.List : [];
                    } else if (res.data.tipoNotificacion) {
                        ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                    }
                })



            //DESACTIVA Div SubSistemas y su contenido
            var nodes = document.getElementById("busqueda").getElementsByTagName('*');
            for (var i = 0; i < nodes.length; i++) {
                nodes[i].disabled = false;
            }
            //fin DESACTIVA Div SubSistemas y su contenido
        },
        DeleteFallasD: async function (e) {
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
            var Id = data[0]
            //delete
            //swal
            Swal.fire({
                title: '¿Estas Seguro?',
                text: "Deseas eliminar esta Observación",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sì, Eliminar esta Observación'
            }).then((result) => {
                if (result.value) {
                    //swal-end
                    axios.post(getBaseUrl.obtenerUrlAbsoluta("Fallas/DeleteFallasD"), { ID: Id })
                        .then(res => {
                            if (res.data.Estado) {

                                Notifications.Messages.success("Registro Eliminado");
                                setTimeout(() => { this.$refs.frmFallasD.submit(); }, 500);

                                console.log(res.data.Estado);
                                window.setTimeout(function () { location.reload() }, 500)

                            } else if (res.data.tipoNotificacion) {

                                ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                            }
                            if (res.data.Estado == false) {
                                Notifications.Messages.warning("esta Observación tiene un mecánico asignado");
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

        Agregar: async function () {
            //codigo y SubSistemas
            //codigo y sistema
            //asigna id maximo desde la bd
            var IdSolD = ""
            var IdSolC = document.getElementById('IdSolicitudRevision').innerHTML;
            var tm = this.$refs.txtCodTipoM.value;
            var ta = this.$refs.txtCodTarea.value
            var obs = document.getElementById('txtObservacion').value;
            var coduser = document.getElementById("lblcodusuario").innerHTML;
            var fecha = new Date();
            var fechar = ""
            var horar = ""
            fechar = (fecha.getDate() + "/" + (fecha.getMonth() + 1) + "/" + fecha.getFullYear());
            horar = "12:00PM";
            console.log(fechar);
            console.log(tm);
            console.log(ta);
            console.log(obs);
            console.log(coduser);
            console.log(horar);

            if (obs.length == 0) {
                console.log(obs.length);
                Notifications.Messages.warning("Ingrese una Observación");
                return
            }

            //swal
            Swal.fire({
                title: '¿Estas Seguro?',
                text: "Deseas grabar este Subsistema",
                type: 'info',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sì, Grabar SubSistema'
            }).then((result) => {
                if (result.value) {
                    //swal-end
                    if (document.getElementById('lblEstadoC').innerHTML == "1") {
                        //get id axios
                        let _this = this;

                        axios.post(getBaseUrl.obtenerUrlAbsoluta("Fallas/IdFallasD"))
                            .then(res => {
                                if (res.data.Estado) {

                                    _this.list.Id = (res.data.Valor.List) ? res.data.Valor.List : [];
                                    //asigna id maximo desde la bd
                                    _this.list.Id = (res.data.Valor.List) ? res.data.Valor.List : [];
                                    //asigna id maximo desde la bd
                                    IdSolD = _this.list.Id[0].IdSolicitudRevisionD;
                                    console.log(IdSolD);

                                    //nuevo elemento
                                    //nuevo
                                    axios.post(getBaseUrl.obtenerUrlAbsoluta("Fallas/InsertFallasD"), {
                                        IdSolicitudRevisionD: IdSolD,IdSolicitudRevision: IdSolC, Observacion: obs, UsuarioRegistro: coduser, FechaRegistro: fechar,
                                        HoraRegistro: horar, Estado: 0, IdSistema: tm, IdObservacion: ta })

                                        .then(res => {
                                            if (res.data.Estado) {
                                                Notifications.Messages.success("Registro Guardado");
                                                setTimeout(() => { this.$refs.frmFallas.submit(); }, 500);
                                                window.setTimeout(function () { location.reload() }, 500)

                                            } else if (res.data.tipoNotificacion) {
                                                ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                                            }
                                        })

                                }
                            }).catch(error => {
                                Notifications.Messages.error('Ocurrió una excepción en el metodo IdSubSistemas');
                            });
                        //fin get id


                    }

                    else {
                        console.log(horar);
                    }


                }
                //swal cierre

                //fin swal 1
            }

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
        "objFallasD.IdSolicitudRevisionD": function (newval, oldval) {
            if (newval) {
                this.SetFocus();
            }
        }
    }
});

 
