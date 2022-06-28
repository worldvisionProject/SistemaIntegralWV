using System.Collections.Generic;

namespace WordVision.ec.Application.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
            };
        }

        public static class Dashboard
        {
            public const string View = "Permissions.Dashboard.View";
            public const string Create = "Permissions.Dashboard.Create";
            public const string Edit = "Permissions.Dashboard.Edit";
            public const string Delete = "Permissions.Dashboard.Delete";
        }

        public static class EstrategiaNacional
        {
            public const string View = "Permissions.EstrategiaNacional.View";
            public const string Create = "Permissions.EstrategiaNacional.Create";
            public const string Edit = "Permissions.EstrategiaNacional.Edit";
            public const string Delete = "Permissions.EstrategiaNacional.Delete";
        }
        public static class IndicadorClicoEstrategico
        {
            public const string View = "Permissions.IndicadorClicoEstrategico.View";
            public const string Create = "Permissions.IndicadorClicoEstrategico.Create";
            public const string Edit = "Permissions.IndicadorClicoEstrategico.Edit";
            public const string Delete = "Permissions.IndicadorClicoEstrategico.Delete";
        }
        public static class ObjetivoBloque
        {
            public const string View = "Permissions.ObjetivoBloque.View";
            public const string Create = "Permissions.ObjetivoBloque.Create";
            public const string Edit = "Permissions.ObjetivoBloque.Edit";
            public const string Delete = "Permissions.ObjetivoBloque.Delete";
        }
        
        public static class ProductoObjetivo
        {
            public const string View = "Permissions.ProductoObjetivo.View";
            public const string Create = "Permissions.ProductoObjetivo.Create";
            public const string Edit = "Permissions.ProductoObjetivo.Edit";
            public const string Delete = "Permissions.ProductoObjetivo.Delete";
        }
        public static class IndicadorProductoObjetivo
        {
            public const string View = "Permissions.IndicadorProductoObjetivo.View";
            public const string Create = "Permissions.IndicadorProductoObjetivo.Create";
            public const string Edit = "Permissions.IndicadorProductoObjetivo.Edit";
            public const string Delete = "Permissions.IndicadorProductoObjetivo.Delete";
        }
        public static class ObjetivoEstrategico
        {
            public const string View = "Permissions.ObjetivoEstrategico.View";
            public const string Create = "Permissions.ObjetivoEstrategico.Create";
            public const string Edit = "Permissions.ObjetivoEstrategico.Edit";
            public const string Delete = "Permissions.ObjetivoEstrategico.Delete";
        }
        public static class Gestion
        {
            public const string View = "Permissions.Gestion.View";
            public const string Create = "Permissions.Gestion.Create";
            public const string Edit = "Permissions.Gestion.Edit";
            public const string Delete = "Permissions.Gestion.Delete";
        }
        public static class FactorCriticoExito
        {
            public const string View = "Permissions.FactorCriticoExito.View";
            public const string Create = "Permissions.FactorCriticoExito.Create";
            public const string Edit = "Permissions.FactorCriticoExito.Edit";
            public const string Delete = "Permissions.FactorCriticoExito.Delete";
        }
        public static class IndicadorEstrategico
        {
            public const string View = "Permissions.IndicadorEstrategico.View";
            public const string Create = "Permissions.IndicadorEstrategico.Create";
            public const string Edit = "Permissions.IndicadorEstrategico.Edit";
            public const string Delete = "Permissions.IndicadorEstrategico.Delete";
        }
        public static class IndicadorAF
        {
            public const string View = "Permissions.IndicadorAF.View";
            public const string Create = "Permissions.IndicadorAF.Create";
            public const string Edit = "Permissions.IndicadorAF.Edit";
            public const string Delete = "Permissions.IndicadorAF.Delete";
        }

        public static class IndicadorPOA
        {
            public const string View = "Permissions.IndicadorPOA.View";
            public const string Create = "Permissions.IndicadorPOA.Create";
            public const string Edit = "Permissions.IndicadorPOA.Edit";
            public const string Delete = "Permissions.IndicadorPOA.Delete";
        }
        public static class Donante
        {
            public const string View = "Permissions.Donante.View";
            public const string Create = "Permissions.Donante.Create";
            public const string Edit = "Permissions.Donante.Edit";
            public const string Delete = "Permissions.Donante.Delete";
        }

        public static class Catalogo
        {
            public const string View = "Permissions.Catalogo.View";
            public const string Create = "Permissions.Catalogo.Create";
            public const string Edit = "Permissions.Catalogo.Edit";
            public const string Delete = "Permissions.Catalogo.Delete";
        }
        public static class Users
        {
            public const string View = "Permissions.Users.View";
            public const string Create = "Permissions.Users.Create";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
        }


    }
}
