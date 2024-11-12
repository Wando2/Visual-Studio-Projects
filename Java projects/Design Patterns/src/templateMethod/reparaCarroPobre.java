package templateMethod;

public class reparaCarroPobre extends reparaCarroService {

    public reparaCarroPobre(VeiculoParaReparo carro) {
        super(carro);
    }

    @Override
    protected boolean podeReparar() {
        return carro.getPorcentagemDano() < 70;
    }
}
