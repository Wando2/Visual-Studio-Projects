package templateMethod;

public class testeTemplate {
    public static void main(String[] args) {

        VeiculoParaReparo carro = new VeiculoParaReparo();
        carro.setPorcentagemDano(50);
        reparaCarroService reparo = new reparaCarroLuxo(carro);
        reparo.reparaCarro();

        carro.setPorcentagemDano(20);
        reparo = new reparaCarroPobre(carro);
        reparo.reparaCarro();

    }

}
