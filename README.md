# EksiChallenge nedir?
Ekşi Teknoloji'yle olan mülakatımın bir parçası olarak geliştirdiğim projedir. Projeyle ilgili daha fazla açıklamayı [buradan](https://www.youtube.com/watch?v=C30Vq3gPFgw) bulabilirsiniz.

## Gereksinimler
EksiChallenge'ın çalışması için bilgisayarınzda .NET Framework v4.6.1'in olması gerekmektedir. Ayrıca [NuGet Package Manager](https://www.nuget.org/)'dan indirilen paketlerin restore edilmesi gerekmektedir. Ayrıca Web.config dosyasındaki <add key="apiKey" value="{YOUR_APIKEY_WILL_BE_HERE}" /> satırına ve Test projelerindeki ilgili yerlere geçerli bir API key girilmesi gerekmektedir.

## İyileştirmeler
EksiChallenge'ın ilk reviewda aldığı değişiklik ve iyileştirme taleplerine uygun olarak aşağıdaki işlemler yapılmıştır;

* Proje mimarisi N-Layer architecture gereksinimlerine göre düzenlendi. 
* Namespacelerde uygun bir hiyerarşi takip edildi.
* Review öncesindeki çoklu sorumluluklar birbirinden ayrıldı. Service datayı almak için kendi altındaki Business katmanı aracılığıyla Repository'ye ulaşır hale geldi.
* UI'da hardcoded yazılan ViewData keyleri yerine Presentation katmanında bir ViewModel tanımlandı ve iletişim onun üzerine çevirildi.
* Viewdaki querystringin tekrar tekrar hardcoded yazılması yerine web.config'den alınan dataları ViewModel ile alarak çalışır hale getirildi.
* Apikey ve Url gibi repository dependent keyler business ve servisten bağımsız hale getirildi.
* Repository, Business ve Service katmanlarına ilgili testler yazıldı.
