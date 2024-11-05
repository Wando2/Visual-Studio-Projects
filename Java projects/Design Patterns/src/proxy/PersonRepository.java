package proxy;

import builder.person;

import java.util.HashMap;
import java.util.Map;

public class PersonRepository {

    private Map<Long, person> pessoas = new HashMap<>();

    public static Long countId = 0L;

    public void save(person pessoa){
        pessoas.put(countId++, pessoa);
    }

    public person get(Long id){
        try {
            return pessoas.get(id);
        } catch (Exception e){
            return null;
        }
    }


}
