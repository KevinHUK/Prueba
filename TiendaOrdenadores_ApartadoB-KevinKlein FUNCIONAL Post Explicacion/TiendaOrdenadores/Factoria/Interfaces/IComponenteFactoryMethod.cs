﻿using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Factoria.Enumeradores;

namespace TiendaOrdenadores.Factoria.Interfaces;

public interface IComponenteFactoryMethod
{
    IComponente dameComponente(TipoComponentes tipo);
}