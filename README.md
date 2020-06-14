Business requirements:                                                                                    
- App should calculate fees per transaction                                                               
- App should take transactions from the file named transactions.txt with the following format:            
Date merchantName amount                                                                                  
- transactions.txt will always contain transactions ordered by date ASC                                   
- App should output result to console with the following format:                                          
   Date merchantName fee     
- Fee amount should be formatted like this 25.00                                                             
- Date should be formatted like this YYYY-MM-DD                                                          
                                                                                                                                                                                                                    
Technical requirements:                                                                                   
- App should be written as Console application in C# (.NET Framework or .NET Core)                        
- Usage of external libraries are prohibited (except tests)                                               
- Output should be written to console                                                                     
- Ubiqutous language should be used in the solution                                               
- Documentation is optional, if there is a need - put in README.md file                                   
- Source code should be pushed to a publicly available git repository (GitHub, GitLab, Bitbucket, ...)    
- Code should be flexible enough to change, add or remove rules                                           
- Code should be covered with tests
- Clean code principles should be applied
- App should output transaction fee as soon as it processes transaction (app should not load all transactions to memory)  
