let app = new Vue({
    el: "#app",
    data: {

        objInforme: {
            IdInforme: '',
            Are_Codigo: '',
            Are_Nombre: '',
            Ofi_Codigo: '',
            Oficina: '',
            Ben_Codigo: '',
            Chofer: '',
            FechaStr: '',
            Hora: '',
            Observacion: '',
            KmUnidad: 0,
            EstCierre: false,
            TipoInforme: '',
            IdUndAlerta: 0,
            NumeroInforme: 0,
            Solicitante: '',
            TipoInformeDesc: '',
            TipoU: ''
        },

        objMantenimiento: {
            IdInforme: '',
            IdTarea: '',
            Observacion: '',
            FechaInicio: ''
        },

        objMecanico: {
            IdInforme: '',
            IdTarea: '',
            CodMecanico: '',
            FechaInicio: '',
            FechaTermino: ''
        },

        objAyudante: {
            IdAyudante: 0,
            IdTareaMecanicos: '',
            CodMecanico: '',
            Observacion: ''
        },

        objFiltro: {
            Fech_ini: '',
            Fech_fin: '',
            NInforme: '',
            TipoU: '2',
            UsrCodigo: '',
            Orden: 'F',
            SoloMiUsuario: false
        },

        list: {
            Informes: [],
            Usuarios: [],
            Sistemas: [],
            Mantenimientos: [],
            Beneficiarios: [],
            Mecanicos: [],
            MecanicosAyudantes: [],
            Ayudantes: []
        },

    },
    created: async function () {
        //await this.ListOrdenMasiva();
        //await this.getFlotas('');
        //await this.getBeneficiarios('');
        //await this.getOrigenes('');
        //await this.getDestinos('');
    },
    mounted: async function () {
        /*this.$nextTick(() => {

        });*/


        $.datetimepicker.setLocale('es');

        $('.dt-picker').datetimepicker({
            format: 'd/m/Y',
            timepicker: false,
            mask: true, // '9999/19/39 29:59' - digit is the maximum possible for a cell
        });

        $('.dtm-picker').datetimepicker({
            format: 'd/m/Y H:i',
            timepicker: true,
            mask: true, // '9999/19/39 29:59' - digit is the maximum possible for a cell
        });

    },

    methods: {

        validateDateFormat: function (evt) {
            var fechaInvalida = "Invalid date";
            var fechaHora = moment(moment(evt, 'DD/MM/YYYY')).format('DD/MM/YYYY');
            return (fechaHora === fechaInvalida) ? "" : fechaHora;
        },

        validateDateTimeFormat: function (evt) {
            var fechaInvalida = "Invalid date";
            var fechaHora = moment(moment(evt, 'DD/MM/YYYY HH:mm')).format('DD/MM/YYYY HH:mm');
            return (fechaHora === fechaInvalida) ? "" : fechaHora;
        },

        getBeneficiarios: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListMecanicosAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Beneficiarios = (res.data.Valor.List) ? res.data.Valor.List : [];

                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getBeneficiarios');
                });
        },

        getMecanicosAyudantes: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListMecanicosAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.MecanicosAyudantes = (res.data.Valor.List) ? res.data.Valor.List : [];

                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getAyudantes');
                });
        },

        getUsuarios: async function (value) {
            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListUsuariosAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Usuarios = (res.data.Valor.List) ? res.data.Valor.List : [];

                    }

                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo getUsuarios');
                });
        },

        getSistemas: async function (value) {

            let _this = this;
            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Base/ListTareasAutocomplete'), { params: { value: value } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Sistemas = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo ListSistemas');
                });
        },

        ShowBuscador: async function () {

            var _this = this;
            _this.getUsuarios('');
            $('#appBuscadorInforme').modal('show');
        },

        ListInforme: async function () {

            let _this = this;

            let data = {
                Filtro: _this.objFiltro
            };

            var json = JSON.stringify(data);

            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Informe/ListInforme'), {
                params: {
                    json: json
                }
            })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Informes = (res.data.Valor.List) ? res.data.Valor.List : [];
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo ListInforme');
                });
        },

        ListInformeTareas: async function () {

            let _this = this;

            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Informe/ListInformeTareas'), {
                params: {
                    IdInforme: _this.objInforme.IdInforme
                }
            })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Mantenimientos = (res.data.Valor.ListInformeTareas) ? res.data.Valor.ListInformeTareas : [];
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo ListInforme');
                });
        },

        SelectInformeCambiar: async function (numeroInforme, tipoInforme, tipoU) {

            let _this = this;
            let existe = false;


            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Informe/SelectInformeCambiar'), {
                params: {
                    NumeroInforme: numeroInforme,
                    TipoInforme: tipoInforme,
                    TipoU: tipoU
                }
            })
                .then(res => {
                    if (res.data.Estado) {
                        if (res.data.Valor.Informe !== null) {
                            _this.objInforme.IdInforme = res.data.Valor.Informe.IdInforme;
                            _this.objInforme.Are_Codigo = res.data.Valor.Informe.Are_Codigo;
                            _this.objInforme.Are_Nombre = res.data.Valor.Informe.Are_Nombre;
                            _this.objInforme.Ofi_Codigo = res.data.Valor.Informe.Ofi_Codigo;
                            _this.objInforme.Oficina = res.data.Valor.Informe.Oficina;
                            _this.objInforme.Ben_Codigo = res.data.Valor.Informe.Ben_Codigo;
                            _this.objInforme.Chofer = res.data.Valor.Informe.Chofer;
                            _this.objInforme.FechaStr = res.data.Valor.Informe.FechaStr;
                            _this.objInforme.Hora = res.data.Valor.Informe.Hora;
                            _this.objInforme.Observacion = res.data.Valor.Informe.Observacion;
                            _this.objInforme.KmUnidad = res.data.Valor.Informe.KmUnidad;
                            _this.objInforme.EstCierre = res.data.Valor.Informe.EstCierre;
                            _this.objInforme.TipoInforme = res.data.Valor.Informe.TipoInforme;
                            _this.objInforme.IdUndAlerta = res.data.Valor.Informe.IdUndAlerta;
                            _this.objInforme.NumeroInforme = res.data.Valor.Informe.NumeroInforme;
                            _this.objInforme.Solicitante = res.data.Valor.Informe.Solicitante;
                            _this.objInforme.Kilometraje = res.data.Valor.Informe.Kilometraje;
                            _this.objInforme.TipoInformeDesc = (res.data.Valor.Informe.TipoInforme === "1") ? "Correctivo" : "Preventivo";
                            _this.objInforme.TipoU = res.data.Valor.Informe.Tipo;
                            existe = true;
                            _this.ListInformeTareas();
                        }
                        
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo SelectInformeCambiar');
                });


            return existe;
        },

        SelectInforme: async function (itemInforme) {

            let _this = this;
            let _idInforme = itemInforme.IdInforme;

            //_this.createAuxilioMecanico = false;

            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Informe/SelectInforme'), { params: { IdInforme: _idInforme } })
                .then(res => {
                    if (res.data.Estado) {
                        _this.objInforme.IdInforme = res.data.Valor.Informe.IdInforme;
                        _this.objInforme.Are_Codigo = res.data.Valor.Informe.Are_Codigo;
                        _this.objInforme.Are_Nombre = res.data.Valor.Informe.Are_Nombre;
                        _this.objInforme.Ofi_Codigo = res.data.Valor.Informe.Ofi_Codigo;
                        _this.objInforme.Oficina = res.data.Valor.Informe.Oficina;
                        _this.objInforme.Ben_Codigo = res.data.Valor.Informe.Ben_Codigo;
                        _this.objInforme.Chofer = res.data.Valor.Informe.Chofer;
                        _this.objInforme.FechaStr = res.data.Valor.Informe.FechaStr;
                        _this.objInforme.Hora = res.data.Valor.Informe.Hora;
                        _this.objInforme.Observacion = res.data.Valor.Informe.Observacion;
                        _this.objInforme.KmUnidad = res.data.Valor.Informe.KmUnidad;
                        _this.objInforme.EstCierre = res.data.Valor.Informe.EstCierre;
                        _this.objInforme.TipoInforme = res.data.Valor.Informe.TipoInforme;
                        _this.objInforme.IdUndAlerta = res.data.Valor.Informe.IdUndAlerta;
                        _this.objInforme.NumeroInforme = res.data.Valor.Informe.NumeroInforme;
                        _this.objInforme.Solicitante = res.data.Valor.Informe.Solicitante;
                        _this.objInforme.Kilometraje = res.data.Valor.Informe.Kilometraje;
                        _this.objInforme.TipoInformeDesc = (res.data.Valor.Informe.TipoInforme === "1") ? "Correctivo" : "Preventivo";
                        _this.objInforme.TipoU = itemInforme.TIPOU;
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo ObtenerInforme');
                });

            _this.getSistemas('');
            _this.ListInformeTareas(_idInforme);
            _this.close(1);
        },

        CambiarTractoCarreta: async function () {

            let _this = this;
            let tipoU = _this.objInforme.TipoU;
            let tipoUnew = (tipoU === 1) ? 2 : 1;
            let numeroInforme = _this.objInforme.NumeroInforme;
            let tipoInforme = _this.objInforme.TipoInforme;

            let existe = await _this.SelectInformeCambiar(numeroInforme, tipoInforme, tipoUnew);

            if (existe === true) {
                if (tipoU === 1) { //TRACTO
                    $('#btnTractoCarreta').text('IR A TRACTO');
                } else { //CARRETA
                    $('#btnTractoCarreta').text('IR A CARRETA');
                }
            } else {
                Notifications.Messages.warning("No se encontró registros");
            }

        },

        CambiarCorrectivoPreventivo: async function () {

            let _this = this;
            let tipoU = _this.objInforme.TipoU;
            let numeroInforme = _this.objInforme.NumeroInforme;
            let tipoInforme = _this.objInforme.TipoInforme;
            let tipoInformeNew = (tipoInforme === "1") ? "0" : "1";

            let existe = await _this.SelectInformeCambiar(numeroInforme, tipoInformeNew, tipoU);

            if (existe === true) {
                if (tipoInforme === "1") { //CORRECTIVO
                    $('#btnCorrectivoPreventivo').text('IR A CORRECTIVO');
                } else {
                    $('#btnCorrectivoPreventivo').text('IR A PREVENTIVO');
                }
            } else {
                Notifications.Messages.warning("No se encontró registros");
            }



        },

        //INICIO MANTENIMIENTO

        saveMantenimiento: async function () {

            var fecha_vacia = "__/__/____";
            var fechaini = $("#Fechahora_ini").val();
            if (fechaini === "" || fechaini === fecha_vacia) {
                Notifications.Messages.warning("Debe ingresar fecha de inicio");
                $("#FechaInicio").focus();
                return;
            }

            await this.InsertMantenimiento();

            //if (this.createAuxilioMecanico) {
            //    await this.InsertAuxilioMecanico();
            //} else {
            //    await this.UpdateAuxilioMecanico();
            //}
        },

        UpdateMantenimiento: async function () {

            let _this = this;
            //this.processing = true;
            await axios.post(getBaseUrl.obtenerUrlAbsoluta('AuxilioMecanico/UpdateAuxilioMecanico'), {
                Carga: _this.objAuxilioMecanico.Carga,
                Are_Codigo: _this.objAuxilioMecanico.Are_Codigo,
                Are_Codigo2: _this.objAuxilioMecanico.Are_Codigo2,
                Kmt_unidad: _this.objAuxilioMecanico.Kmt_unidad,
                Kmt_recorrido: _this.objAuxilioMecanico.Kmt_recorrido,
                MMG: _this.objAuxilioMecanico.MMG,
                Fechahora_ini: $("#Fechahora_ini").val(),
                Fechahora_fin: $("#Fechahora_fin").val(),
                Controlable: _this.objAuxilioMecanico.Controlable,
                Id_plataforma: _this.objAuxilioMecanico.Id_plataforma,
                Idtarea_c: _this.objAuxilioMecanico.Idtarea_c,
                Falla: _this.objAuxilioMecanico.Falla,
                Ben_codigo: _this.objAuxilioMecanico.Ben_codigo,
                Servicio: _this.objAuxilioMecanico.Servicio,
                Kmt_Perdido: _this.objAuxilioMecanico.Kmt_Perdido,
                CambioTracto: _this.objAuxilioMecanico.CambioTracto,
                Responsable: _this.objAuxilioMecanico.Responsable,
                Atencion: _this.objAuxilioMecanico.Atencion,
                Causa: _this.objAuxilioMecanico.Causa,
                IdPlan: _this.objAuxilioMecanico.IdPlan,
                ID_Tb_AuxilioMecanico: _this.objAuxilioMecanico.IdAuxilioMecanico
            })
                .then(res => {
                    if (res.data.Estado) {
                        this.close(1);
                        Notifications.Messages.success('Se grabó información exitosamente');
                        this.ListAuxilioMecanico();
                    } else if (res.data.Estado === false) {
                        //this.processing = false;
                        Notifications.Messages.error(res.data.Mensaje);
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo UpdateAuxilioMecanico');
                });
        },

        InsertMantenimiento: async function () {

            let _this = this;

            _this.objMantenimiento.IdInforme = _this.objInforme.IdInforme;

            let data = {
                InformeTareas: _this.objMantenimiento
            };

            var json = JSON.stringify(data);

            //this.processing = true;
            await axios.post(getBaseUrl.obtenerUrlAbsoluta('Informe/InsertInformeTarea'), {
                json: json
            })
                .then(res => {
                    if (res.data.Estado) {
                        Notifications.Messages.success('Se grabó información exitosamente');
                        this.ListInformeTareas();
                    } else if (res.data.tipoNotificacion) {
                        ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                    } else if (res.data.tip){
                        Notifications.Messages.warning(res.data.Mensaje);
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo InsertMantenimiento');
                });
        },

        DeleteMantenimiento: async function (itemMantenimiento) {

            let _this = this;
            //this.processing = true;

            Swal.fire({
                title: '¿Estas Seguro?',
                text: "Deseas eliminar este registro",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sì, Eliminar Registro'
            }).then((result) => {
                if (result.value) {
                    //swal-end
                    axios.post(getBaseUrl.obtenerUrlAbsoluta('Informe/DeleteInformeTarea'), { IdInforme: _this.objInforme.IdInforme, IdTarea: itemMantenimiento.IdTarea })
                        .then(res => {
                            if (res.data.Estado) {
                                Notifications.Messages.success('Se eliminó registro exitosamente');
                                this.ListInformeTareas();

                            }
                            if (res.data.Estado === false) {
                                Notifications.Messages.warning("esta registro no se pudo eliminar");
                            }

                        }).catch(error => {
                            Notifications.Messages.error('Ocurrió una excepción en el metodo DeleteMantenimiento');
                        });
                    //fin delete    
                    //fin swal 1
                }


            })
            //fin swal2

        },

        SelectMantenimiento: async function (itemMantenimiento) {

            let _this = this;
            _this.objMecanico.IdTarea = itemMantenimiento.IdTarea;
            _this.ListMecanicos(itemMantenimiento.IdTarea);
            _this.getBeneficiarios('');
        },

        //FIN MANTENIMIENTO

        //INICIO MECANICO

        ListMecanicos: async function (IdTarea) {

            let _this = this;

            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Informe/ListTareaMecanico'), {
                params: {
                    IdInforme: _this.objInforme.IdInforme,
                    IdTarea: IdTarea
                }
            })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Mecanicos = (res.data.Valor.ListTareaMecanico) ? res.data.Valor.ListTareaMecanico : [];
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo ListMecanicos');
                });
        },

        saveMecanico: async function () {

            let _this = this;

            var fecha_vacia = "__/__/____ __:__";
            var fechaini = _this.objMecanico.FechaInicio;
            var fechafin = _this.objMecanico.FechaTermino;
            if (fechaini === "" || fechaini === fecha_vacia) {
                Notifications.Messages.warning("Debe ingresar fecha de inicio");
                //$("#Fechahora_ini").focus();
                return;
            }

            if (fechafin === "" || fechafin === fecha_vacia) {
                Notifications.Messages.warning("Debe ingresar fecha de termino");
                //$("#Fechahora_fin").focus();
                return;
            }

            await _this.InsertMecanico();

            //if (this.createAuxilioMecanico) {
            //    await this.InsertAuxilioMecanico();
            //} else {
            //    await this.UpdateAuxilioMecanico();
            //}
        },

        UpdateMecanico: async function () {
                       
        },

        InsertMecanico: async function () {

            let _this = this;

            _this.objMecanico.IdInforme = _this.objInforme.IdInforme;

            let data = {
                TareaMecanico: _this.objMecanico
            };

            var json = JSON.stringify(data);

            //this.processing = true;
            await axios.post(getBaseUrl.obtenerUrlAbsoluta('Informe/InsertTareaMecanico'), {
                json: json
            })
                .then(res => {
                    if (res.data.Estado) {
                        Notifications.Messages.success('Se grabó información exitosamente');
                        this.ListMecanicos(_this.objMecanico.IdTarea);
                    } else if (res.data.tipoNotificacion) {
                        ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                    } else if (res.data.tip) {
                        Notifications.Messages.warning(res.data.Mensaje);
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo InsertMantenimiento');
                });
        },

        DeleteMecanico: async function (itemMecanico) {

            let _this = this;
            //this.processing = true;

            Swal.fire({
                title: '¿Estas Seguro?',
                text: "Deseas eliminar este registro",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sì, Eliminar Registro'
            }).then((result) => {
                if (result.value) {
                    //swal-end
                    axios.post(getBaseUrl.obtenerUrlAbsoluta('Informe/DeleteTareaMecanico'), { IdTareaMecanico: itemMecanico.IdTareaMecanicos })
                        .then(res => {
                            if (res.data.Estado) {
                                Notifications.Messages.success('Se eliminó registro exitosamente');
                                _this.ListMecanicos(_this.objMecanico.IdTarea);
                            }
                            if (res.data.Estado === false) {
                                Notifications.Messages.warning("esta registro no se pudo eliminar");
                            }

                        }).catch(error => {
                            Notifications.Messages.error('Ocurrió una excepción en el metodo DeleteMantenimiento');
                        });
                    //fin delete    
                    //fin swal 1
                }


            })
            //fin swal2

        },

        //FIN MECANICO

        //INICIO AYUDANTES

        ShowAyudantes: async function (itemMecanico) {
            var _this = this;
            _this.objAyudante.IdTareaMecanicos = itemMecanico.IdTareaMecanicos;
            _this.getMecanicosAyudantes('');
            _this.ListAyudantes();
            $('#appAyudantes').modal('show');
        },

        ListAyudantes: async function () {

            let _this = this;

            await axios.get(getBaseUrl.obtenerUrlAbsoluta('Informe/ListTareaMecanicosAyudante'), {
                params: {
                    IdTareaMecanico: _this.objAyudante.IdTareaMecanicos
                }
            })
                .then(res => {
                    if (res.data.Estado) {
                        _this.list.Ayudantes = (res.data.Valor.ListTareaMecanicosAyudante) ? res.data.Valor.ListTareaMecanicosAyudante : [];
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo ListAyudantes');
                });
        },

        saveAyudante: async function () {

            let _this = this;
 
            await _this.InsertAyudante();
        },

        InsertAyudante: async function () {

            let _this = this;

            _this.objAyudante.Observacion = _this.$refs.CodMecanicoAyudante.$refs.selectedOptions.innerText;

            let data = {
                TareaMecanicosAyudante: _this.objAyudante
            };

            var json = JSON.stringify(data);

            //this.processing = true;
            await axios.post(getBaseUrl.obtenerUrlAbsoluta('Informe/InsertTareaMecanicosAyudante'), {
                json: json
            })
                .then(res => {
                    if (res.data.Estado) {
                        Notifications.Messages.success('Se grabó información exitosamente');
                        _this.ListAyudantes(_this.objAyudante.IdTareaMecanico);
                    } else if (res.data.tipoNotificacion) {
                        ProcessMessage(res.data.tipoNotificacion, res.data.mensaje);
                    } else if (res.data.tip) {
                        Notifications.Messages.warning(res.data.Mensaje);
                    }
                }).catch(error => {
                    Notifications.Messages.error('Ocurrió una excepción en el metodo InsertMantenimiento');
                });
        },

        DeleteAyudante: async function (itemAyudante) {

            let _this = this;
            //this.processing = true;

            Swal.fire({
                title: '¿Estas Seguro?',
                text: "Deseas eliminar este registro",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sì, Eliminar Registro'
            }).then((result) => {
                if (result.value) {
                    //swal-end
                    axios.post(getBaseUrl.obtenerUrlAbsoluta('Informe/DeleteTareaMecanicosAyudante'), { IdAyudante: itemAyudante.IdAyudante })
                        .then(res => {
                            if (res.data.Estado) {
                                Notifications.Messages.success('Se eliminó registro exitosamente');
                                _this.ListAyudantes(_this.objAyudante.IdTareaMecanico);
                            }
                            if (res.data.Estado === false) {
                                Notifications.Messages.warning("esta registro no se pudo eliminar");
                            }

                        }).catch(error => {
                            Notifications.Messages.error('Ocurrió una excepción en el metodo DeleteMantenimiento');
                        });
                    //fin delete    
                    //fin swal 1
                }
            })
            //fin swal2

        },

        //FIN AYUDANTES

        close: function (code) {
            if (code === 1) {
                $('#appBuscadorInforme').modal('hide');
                this.$nextTick(() => {

                });
            } else if (code === 2) {
                $('#appAyudantes').modal('hide');
                this.$nextTick(() => {

                });
            } else if (code === 3) {
                $('#appRequisicion').modal('hide');
                this.$nextTick(() => {

                });
            }
        }

    },

    computed: {
        FullMantenimiento: function () {
            return (
                this.objInforme.IdInforme &&
                this.objMantenimiento.IdTarea &&
                this.objMantenimiento.Observacion &&
                this.objMantenimiento.FechaInicio
            ) ? true : false;
        },
        FullInforme: function () {
            return (
                this.objInforme.IdInforme
            ) ? true : false;
        },
        FullMecanico: function () {
            return (
                this.objInforme.IdInforme &&
                this.objMecanico.IdTarea &&
                this.objMecanico.Observacion &&
                this.objMecanico.FechaInicio
            ) ? true : false;
        },
        FullNuevoMecanico: function () {
            return (
                this.objInforme.IdInforme &&
                this.objMecanico.IdTarea
            ) ? true : false;
        },
    },

    watch: {
        /*"objTareaM.IdTarea": function (newval, oldval) {
            if (newval) {
                this.SetFocus();
            }
        }*/
    }
});


