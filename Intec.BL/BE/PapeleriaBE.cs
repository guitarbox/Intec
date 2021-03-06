﻿using AutoMapper;
using Intec.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class PapeleriaBE : _beDefault
    {

        #region Formatos

        //Crear
        public void CrearFormato(DTO.Formatos Formato)
        {
            new DAL.TE.PapeleriaTE().CrearFormato(MapperConfig.Config.MapperPapeleria.Map<DAL.Formatos>(Formato));
        }

        //Obtener
        public List<DTO.Formatos> ConsultarFormatos()
        {
            return MapperConfig.Config.MapperPapeleriaSimple.Map<List<DTO.Formatos>>(new DAL.TE.PapeleriaTE().ConsultarFormatos());
        }

        public DTO.Formatos ConsultarFormato(int IdFormato)
        {
            return MapperConfig.Config.MapperPapeleria.Map<DTO.Formatos>(new DAL.TE.PapeleriaTE().ConsultarFormato(IdFormato));
        }

        //Editar
        public void EditarFormato(DTO.Formatos Formato, int IdUsuariomodificacion)
        {
            new DAL.TE.PapeleriaTE().EditarFormato(MapperConfig.Config.MapperPapeleria.Map<DAL.Formatos>(Formato), IdUsuariomodificacion);
        }

        //Eliminar
        public void EliminarFormato(int IdFormato)
        {
            new DAL.TE.PapeleriaTE().EliminarFormato(IdFormato);
        }

        //Asignación de consecutivos a inspectores

        public void AsignarRangoConsecutivosFormatoInspector(int IdFormato, int IdInspector, int ConsecutivoInicial, int ConsecutivoFinal, int IdUsuarioAsigna)
        {
            new DAL.TE.PapeleriaTE().AsignarRangoConsecutivosFormatoInspector(IdFormato, IdInspector, ConsecutivoInicial, ConsecutivoFinal, IdUsuarioAsigna);
        }

        //Ingresar consecutivos a bodega
        public void IngresarConsecutivosFormatoBodega(int IdFormato, int ConsecutivoInicial, int ConsecutivoFinal, int IdUsuarioAsigna)
        {
            new DAL.TE.PapeleriaTE().IngresarConsecutivosFormatoBodega(IdFormato, ConsecutivoInicial, ConsecutivoFinal, IdUsuarioAsigna);
        }

        //Actualizar estado Consecutivo
        public void ActualizarEstadoConsecutivo(int IdFormato, int ConsecutivoInicial, int ConsecutivoFinal, string IdEstado, int IdUsuarioActualiza, string Observaciones)
        {
            List<int> Consecutivos = new List<int>();
            while (ConsecutivoInicial <= ConsecutivoFinal)
            {
                Consecutivos.Add(ConsecutivoInicial);
                ConsecutivoInicial += 1;
            }
            new DAL.TE.PapeleriaTE().ActualizarEstadoConsecutivo(IdFormato, Consecutivos, IdEstado, IdUsuarioActualiza, Observaciones);
        }

        //Actualizar estado Consecutivos
        public void ActualizarEstadoConsecutivos(string IdEstado, int IdUsuarioActualiza, string Observaciones)
        {
            new DAL.TE.PapeleriaTE().ActualizarEstadoConsecutivosUsuAplica(IdEstado, IdUsuarioActualiza, Observaciones);
        }

        public List<DTO.TramiteConsecutivoFormato> ConsultarTramiteConsecutivoFormato(int IdFormato, int Consecutivo)
        {
            List<DAL.TramiteConsecutivoFormato> t = new DAL.TE.PapeleriaTE().ConsultarTramiteConsecutivoFormato(IdFormato, Consecutivo);
            return MapperConfig.Config.MapperTramite_Consecutivo.Map<List<DTO.TramiteConsecutivoFormato>>(t);
        }

        public List<DTO.ConsecutivosFormatos> ObtenerConsecutivosUsuario(int IdUsuario)
        {
            return MapperConfig.Config.MapperTramite_Consecutivo.Map<List<DTO.ConsecutivosFormatos>>( new DAL.TE.PapeleriaTE().ObtenerConsecutivosUsuario(IdUsuario));
        }
        #endregion

    }
}
