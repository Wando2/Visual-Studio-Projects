package chainOfResponsability;

import java.math.BigDecimal;

public class descontoCarro100K extends descontoCarro {

    public descontoCarro100K(descontoCarro proximo) {
        super(proximo);
    }

    @Override
    public BigDecimal desconta(carro carro) {
        if (carro.getValor().compareTo(new BigDecimal(100000)) > 0){
            return carro.getValor().add(new BigDecimal(-7000));
        }
        return proximo.desconta(carro);
    }

}
