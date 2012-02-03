namespace :growl do
  desc 'Start the growl monitor'
  task :start do
    system("start build/tools/growl/Growl.exe")
  end
end
