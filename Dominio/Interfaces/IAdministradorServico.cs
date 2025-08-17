using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;
using System.Collections.Generic;

namespace MinimalApi.Dominio.Interfaces;
public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
}