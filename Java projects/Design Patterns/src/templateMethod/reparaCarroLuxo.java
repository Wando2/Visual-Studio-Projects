package templateMethod;

public class reparaCarroLuxo extends reparaCarroService {

    public reparaCarroLuxo(VeiculoParaReparo carro) {
        super(carro);
    }

    @Override
    protected boolean podeReparar() {
        return carro.getPorcentagemDano() < 40;
    }
}
