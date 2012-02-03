configs ={
  :git => {
    :user => "daxkopair",
    :remotes => %w[stgwilli],
    :repo => 'authentication_spike' 
  }
}
configatron.configure_from_hash(configs)
