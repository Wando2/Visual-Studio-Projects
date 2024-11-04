package singleton;

import java.util.Dictionary;
import java.util.HashMap;
import java.util.Map;

public enum agenda {
    instance;

    private Map<String,Boolean> daysOfWeek = new HashMap<>();



    private agenda(){
        daysOfWeek.put("Monday", false);
        daysOfWeek.put("Tuesday", false);
        daysOfWeek.put("Wednesday", false);
        daysOfWeek.put("Thursday", false);
        daysOfWeek.put("Friday", false);
        daysOfWeek.put("Saturday", false);
        daysOfWeek.put("Sunday", false);
    }

    public static agenda getInstance(){
        return instance;
    }

    public void setDay(String day, Boolean busy){
        daysOfWeek.put(day, busy);
       System.out.println(daysOfWeek);
    }

}
