package templateMethod;

public  abstract class reparaCarroService {
    protected VeiculoParaReparo carro;

    public reparaCarroService(VeiculoParaReparo carro) {
        this.carro = carro;
    }

    public void reparaCarro(){
        entradaOficina();
        analisarDanos();
        if(podeReparar()){
            System.out.println("Reparando carro e comunicando a seguradora");
        } else {
            System.out.println("Carro não pode ser reparado kk se fudeu");
        }

    }

   protected void entradaOficina(){
        System.out.println("Entrada na oficina");
    }

    protected void analisarDanos(){
        System.out.println("Analisando danos: " + carro.getPorcentagemDano() + "%");
    }

   protected abstract boolean podeReparar();




}
