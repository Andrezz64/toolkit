using ToolKit.Interfaces;
using ToolKit.Modules;

namespace ToolKit.Factory
{
    public class ModuleFactory
    {
        public IModulo CriarModulo(int opcao) => opcao switch
        {
            1 => new VerificadorAlfabeto(),
            2 => new ClassificadorTIN(),
            3 => new DecisorTerminaComB(),
            4 => new AvaliadorProposicional(),
            5 => new ReconhecedorLinguagens(),
            _ => throw new ArgumentException("Módulo inválido", nameof(opcao))
        };
    }
}