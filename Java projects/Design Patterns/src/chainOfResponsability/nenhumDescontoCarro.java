package chainOfResponsability;

import java.math.BigDecimal;

public class nenhumDescontoCarro extends descontoCarro {

    public nenhumDescontoCarro(descontoCarro proximo) {
        super(proximo);
    }

    @Override
    public BigDecimal desconta(carro carro) {
        return carro.getValor();
    }
}
