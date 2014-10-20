CREATE TABLE VOC_LEVEL ( 
    ID   INTEGER         PRIMARY KEY,
    NAME VARCHAR( 255 )  NOT NULL 
);

CREATE TABLE VOC_ADDRESS_TYPE ( 
    ID       INTEGER           PRIMARY KEY AUTOINCREMENT,
    LEVEL    INTEGER( 10 )     NOT NULL,
    SCNAME   VARCHAR( 0, 10 ),
    SOCRNAME VARCHAR( 0, 50 )  NOT NULL,
    KOD_T_ST VARCHAR( 1, 4 )   NOT NULL,
    POINT    BOOLEAN           NOT NULL,
    [LEFT]   BOOLEAN           NOT NULL
                               DEFAULT ( 0 ) 
);

CREATE INDEX idx_ADDRESS_TYPE ON VOC_ADDRESS_TYPE ( 
    SOCRNAME ASC,
    LEVEL    ASC 
);

CREATE TABLE VOC_ADDRESS_OBJECT ( 
    ID         INTEGER            PRIMARY KEY ASC AUTOINCREMENT,
    AOGUID     VARCHAR( 36 )      NOT NULL,
    FORMALNAME VARCHAR( 1, 120 )  NOT NULL,
    REGIONCODE VARCHAR( 2 )       NOT NULL,
    AUTOCODE   VARCHAR( 1 )       NOT NULL,
    AREACODE   VARCHAR( 3 )       NOT NULL,
    CITYCODE   VARCHAR( 3 )       NOT NULL,
    CTARCODE   VARCHAR( 3 )       NOT NULL,
    PLACECODE  VARCHAR( 3 )       NOT NULL,
    STREETCODE VARCHAR( 4 )       NOT NULL,
    EXTRCODE   VARCHAR( 4 )       NOT NULL,
    SEXTCODE   VARCHAR( 3 )       NOT NULL,
    OFFNAME    VARCHAR( 1, 120 ),
    POSTALCODE VARCHAR( 6 ),
    IFNSFL     VARCHAR( 4 ),
    TERRIFNSFL VARCHAR( 4 ),
    IFNSUL     VARCHAR( 4 ),
    TERRIFNSUL VARCHAR( 4 ),
    OKATO      VARCHAR( 11 ),
    OKTMO      VARCHAR( 11 ),
    UPDATEDATE DATE               NOT NULL,
    SHORTNAME  VARCHAR( 1, 10 )   NOT NULL,
    AOLEVEL    INTEGER( 10 )      NOT NULL,
    PARENTGUID VARCHAR( 36 ),
    AOID       VARCHAR( 36 )      NOT NULL
                                  UNIQUE ON CONFLICT ABORT,
    PREVID     VARCHAR( 36 ),
    NEXTID     VARCHAR( 36 ),
    CODE       VARCHAR( 0, 17 ),
    PLAINCODE  VARCHAR( 0, 15 ),
    ACTSTATUS  INTEGER( 10 )      NOT NULL,
    CENTSTATUS INTEGER( 10 )      NOT NULL,
    OPERSTATUS INTEGER( 10 )      NOT NULL,
    CURRSTATUS INTEGER( 10 )      NOT NULL,
    STARTDATE  DATE               NOT NULL,
    ENDDATE    DATE               NOT NULL,
    NORMDOC    VARCHAR( 36 ),
    LIVESTATUS INTEGER( 1 )       NOT NULL 
);

CREATE INDEX idx_ADDRESS_OBJECT ON VOC_ADDRESS_OBJECT ( 
    SHORTNAME  ASC,
    CURRSTATUS ASC,
    PARENTGUID ASC,
    AOLEVEL    ASC,
    AOGUID     ASC 
);

CREATE INDEX idx_VOC_ADDRESS_OBJECT ON VOC_ADDRESS_OBJECT ( 
    CURRSTATUS,
    PARENTGUID 
);

CREATE TABLE FIAS_UPDATE_VERSION ( 
    VERSION     INTEGER PRIMARY KEY,
    UPDATE_DATE DATE    NOT NULL 
);

CREATE TABLE HOUSE ( 
    id              INTEGER        PRIMARY KEY ASC AUTOINCREMENT,
    city_or_area_id INTEGER        REFERENCES VOC_ADDRESS_OBJECT ( ID ),
    postal_code     VARCHAR( 6 ),
    house_number    VARCHAR( 10 ),
    housing_number  VARCHAR( 10 ),
    room_number     VARCHAR( 10 ),
    place_id        INTEGER        REFERENCES VOC_ADDRESS_OBJECT ( ID ),
    street_id       INTEGER        REFERENCES VOC_ADDRESS_OBJECT ( ID ) 
);

CREATE TABLE ORGANIZATION ( 
    NAME     VARCHAR( 250 )  NOT NULL,
    INN      VARCHAR( 10 )   NOT NULL,
    KPP      VARCHAR( 9 ),
    HOUSE_ID INTEGER         REFERENCES HOUSE ( id ) 
);

CREATE TABLE communication_folders ( 
    load_folder   VARCHAR,
    unload_folder VARCHAR 
);

CREATE TABLE exempt_service ( 
    id                  INTEGER PRIMARY KEY ASC AUTOINCREMENT,
    exempt_id                   REFERENCES EXEMPT ( ID ),
    period              DATE    NOT NULL,
    payment_amount      REAL,
    penalties_amount    REAL,
    debt_amount         REAL,
    debt_month_count    INTEGER,
    payment_debt_amount REAL 
);

CREATE TABLE exempt_service_detail ( 
    id                     INTEGER PRIMARY KEY ASC AUTOINCREMENT,
    voc_service_id         INTEGER REFERENCES voc_service ( id ),
    rate                   REAL,
    norm                   REAL,
    service_volume         REAL,
    parameter              VARCHAR,
    accrued_amount         REAL,
    penalties_amount       REAL,
    paid_amount            REAL,
    recalculated_amount    REAL,
    recalculate_start_date DATE,
    recalculate_end_date   DATE,
    exempt_service_id      INTEGER REFERENCES exempt_service ( id ) 
);

CREATE TABLE family_members ( 
    id                     INTEGER         PRIMARY KEY ASC AUTOINCREMENT,
    last_name              VARCHAR( 255 ),
    name                   VARCHAR( 255 ),
    middle_name            VARCHAR( 255 ),
    birth_date             DATE,
    sex                    VARCHAR( 7 ),
    is_owner               BOOLEAN         DEFAULT ( 0 ),
    relationship_degree_id INTEGER         REFERENCES relationship_degree ( id ),
    exempt_id              INTEGER         REFERENCES EXEMPT ( ID ) 
);

CREATE TABLE voc_relationship_degree ( 
    id     INTEGER         PRIMARY KEY ASC AUTOINCREMENT,
    name   VARCHAR( 255 )  NOT NULL,
    active BOOLEAN         DEFAULT ( 1 ) 
);

CREATE TABLE voc_service ( 
    id     INTEGER        PRIMARY KEY ASC AUTOINCREMENT,
    code   INTEGER( 6 )   NOT NULL,
    name   VARCHAR( 50 ),
    unit   VARCHAR( 10 ),
    active BOOLEAN        DEFAULT ( 1 ) 
);

CREATE TABLE EXEMPT ( 
    ID                     INTEGER         PRIMARY KEY,
    create_date            DATE            NOT NULL,
    personal_account       VARCHAR,
    last_name              VARCHAR( 255 ),
    name                   VARCHAR( 255 ),
    middle_name            VARCHAR( 255 ),
    birth_date             DATE,
    sex                    VARCHAR( 7 ),
    SNILS                  VARCHAR,
    document_name          VARCHAR( 255 ),
    document_series        VARCHAR( 10 ),
    document_number        VARCHAR( 10 ),
    document_date          DATE,
    document_issuer        VARCHAR( 255 ),
    house_id               INTEGER         REFERENCES HOUSE ( id ),
    loaded                 BOOLEAN         DEFAULT ( 0 ),
    has_family_composition BOOLEAN         DEFAULT ( 1 ) 
);

CREATE TABLE EXEMPT_HOUSEROOM ( 
    ID                   INTEGER PRIMARY KEY AUTOINCREMENT,
    property_type        VARCHAR,
    is_owner             BOOLEAN,
    total_area           REAL,
    living_area          REAL,
    residents_count      INTEGER,
    rooms_count          INTEGER,
    family_members_count INTEGER,
    exempt_id            INTEGER REFERENCES EXEMPT ( ID ) 
);

CREATE INDEX idx_EXEMPT_HOUSEROOM ON EXEMPT_HOUSEROOM ( 
    exempt_id 
);

CREATE INDEX idx_exempt_service ON exempt_service ( 
    period,
    exempt_id 
);

CREATE INDEX idx_exempt_service_detail ON exempt_service_detail ( 
    exempt_service_id 
);

CREATE INDEX idx_family_members ON family_members ( 
    exempt_id 
);