package Prototype;

import java.util.HashMap;
import java.util.Map;

public class bottonRegister {
    private static bottonRegister Buttonregister;

    private static Map<String,botton> REGISTRY = new HashMap<>();

    static {
        botton botaoVerde = new botton("verde", 10, 10, ButtonType.ROUND);
        botton botaoAzul = new botton("azul", 10, 10, ButtonType.SQUARE);
        botton botaoVermelho = new botton("vermelho", 10, 10, ButtonType.RECTANGLE);

        REGISTRY.put("verde", botaoVerde);
        REGISTRY.put("azul", botaoAzul);
        REGISTRY.put("vermelho", botaoVermelho);
    }

    public static botton getBotton(String key){
        return bottonFactory.getInstance(REGISTRY.get(key));

    }
}
