package proxy;

import builder.person;

import java.util.logging.Logger;

public class PRepositoryProxy extends PersonRepository {
    private static Logger log = Logger.getLogger(PRepositoryProxy.class.getName());

    @Override
    public void save(person pessoa) {
        log.info("Salvando pessoa: " + pessoa.toString());
        super.save(pessoa);
    }

    @Override
    public person get(Long id) {
        log.info("Buscando pessoa com id: " + id);
        return super.get(id);
    }
}
