# qbank3api-dotnetwrapper

A first stab at offering a wrapper around the QBank3 API, all code here is automatically created based on our swagger spec, please report any problems in Github Issues.

## Usage

### Getting a QBankApi instance
```
var credentials = new Credentials("<your client_id>", "<username>", "<password>");
var api = new QBankApi.QBankApi(credentials, "https://<yourinstance>.qbank.se/api/");
```

### Searching
```
var search = new Search()
{
    FreeText = "some query",
    Properties = new List<PropertyCriteria>()
    {
        new PropertyCriteria()
        {
            SystemName = "some property",
            Value = "with a value",
            Operator = "="
        }
    }
};

var results = api.Search.Search(search); // Returns a SearchResult
```

### Working with Folders
Retrieves all folders in the root, 2 levels down, without any properties
```
var folders = api.Folders.ListFolders(0, 2, false);
```
