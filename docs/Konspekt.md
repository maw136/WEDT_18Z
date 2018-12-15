# WEDT

## Projekt - dokumentacja wstępna

### Zespół

- Łukasz Świątkowski
- Maciej Walanus

### Temat

System rozpoznawania języka dokumentów, obsługujący najważniejsze języki europejskie, wraz z analizą porównawczą dwóch opracowanych algorytmów.

#### Rozpoznanie języka dokumentów

Planowane jest rozpoznawanie języków takich jak: polski, angielski, niemiecki, francuski, hiszpański, włoski, portugalski. Docelowa liczba języków zależy od końcowej dostępności oraz jakości danych mających służyć analizie. W ramach projektu, oprócz stworzenia samego systemu rozpoznawania języka dokumentów, zostanie przeprowadzona analiza porównawcza opracowanych przez zespół algorytmów wraz z opisem stosowalności obu metod dla różnych typów analizowanych dokumentów. Pod uwagę będą wzięte m. in. takie właściwości jak długość, rodzaj dokumentu (ogólny lub z konkretnej dziedziny), rodzaj języka (formalny lub potoczny). Poniżej przedstawione zostały przyjęte założenia i przewidywane ograniczenia systemu wraz z propozycjami, które mogą posłużyć ulepszeniu algorytmów.

#### Przewidywane ograniczenia systemu

Przy tworzeniu rozwiązania zakładamy, że analizowane teksty nie są bogate w zapożyczenia z innych języków; cytaty są zazwyczaj przetłumaczone na język artykułu, a jeśli nie to nie stanowią istotnego objętościowo fragmentu tekstu.

#### Przygotowanie do analizy

Algorytmy rozpoznawania będą oparte o zbiory najczęściej występujących słów w danym języku wraz z częstotliwością ich występowania (w zależności od algorytmu). Omawiane zbiory są powszechnie dostępne dla większości języków europejskich. Napotkany może zostać problem określenia częstotliwości występowania słów, ponieważ w wielu źródłach podana jest liczba wystąpień znaleziona w przeanalizowanych pod tym kątem materiałach, natomiast nie ma podanej referencyjnej liczby słów. Znalezienie odpowiednich zbiorów możliwych do wykorzystania wymaga dalszej pracy. Przewiduje się, że zbiory powinny mieć około 3000 słów. W trakcie pracy nad algorytmami wartość ta zostanie dostosowana w celu poprawy ich działania.

Niezależnie od rozpatrywanego algorytmu, przed rozpoczęciem analizy językowej należy przeprowadzić tokenizację wybranego tekstu. W tym celu planowane jest wykorzystanie ogólnodostępnej biblioteki. Prawdopodobnie nie będzie możliwe rozpoznawanie także odmienionej formy słów, ponieważ na tym etapie nie jest znany język tekstu, co znacząco utrudnia (jeśli nie uniemożliwia) rozpoznania podstawowej formy słowa.

### Algorytm 1

Dla każdego tokenu określana jest jego przynależność do każdego z rozpatrywanych języków. Na koniec procesu obliczane prawdopodobieństwo języka na podstawie sumarycznej liczby występowania słów w danym języku. To znaczy im więcej słów tekstu ma okrreśloną przynależność do danego języka tym wyższa jest wartość oceny języka dokumentu. Wynikiem działania algorytmu jest lista par (język - wartość oceny pewności algorytmu).

#### Przykład

Dokument wejściowy składa się z 300 słów. Algorytm zidentyfikował 150 słów występujących w języku polskim, 30 w czeskim i 15 w angielskim. Pozostało 135 niezidentyfikowanych słów z uwagi na ograniczoną bazę porównawczą. Porównując częstotliwość wystąpień słowa w każdym z języków, algorytm zidentyfikował język tekstu jako polski z określonym prawdopodobieństwem:
(liczba zidentyfikownaych słów w języku polskim / liczba wszystkich zidentyfikowanych słów): <!-- 150/165 = 0,91 --> ![img](http://latex.codecogs.com/svg.latex?%5Cfrac%7B150%7D%7B165%7D%3D0%2C91)

### Algorytm 2 (podejście rozszerzone)

Dla wszystkich słów w dokumencie następuje zliczanie liczby ich wystąpień w tekście i mnożenie liczby wystąpień przez częstotliwość występowania słowa w rozpoznawanym języku. Następnie wyniki zostają zsumowane, a im wyższy wynik tym bardziej prawdopodobne, że rozpoznany został dany język. Zespół spodziewa się, że metoda ta lepiej nadaje się do dłuższych tekstów w porównaniu do pierwszego algorytmu przedstawionego. Oszacowanie to jest uzasadnione tym, że w wypadku dłuższych tekstów wiele słów przynależy do wielu języków europejskich mimo różnych znaczeń.

### Przewidywane możliwości usprawnienia algorytmów

- wykrywanie i rozpoznawanie znaków diakrytycznych (niektóre występują tylko w określonych językach; zawężają zakres możliwych języków)
- odfiltrowanie najkrótszych słów (mniej niż 3 lub 4 znaki) na początku procesu rozpoznawania (wiele krótkich słów pojawia się często w wielu językach)
