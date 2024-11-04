package singleton;

public class singletonTeste {
    public static void main(String[] args) {
       agenda agende = agenda.getInstance();
       agende.setDay("Monday", true);
       agende.setDay("Tuesday", true);


    }
}
