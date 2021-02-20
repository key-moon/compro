#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  cout << setprecision(15);
  int p, d;
  cin >> p >> d;
  vector<vector<int>> votes(d, vector<int>(2));
  for (int i = 0; i < p; i++) {
    int ind, a, b;
    cin >> ind >> a >> b;
    ind--;
    votes[ind][0] += a;
    votes[ind][1] += b;
  }
  int totalVotes = 0;
  int totalWasteA = 0;
  int totalWasteB = 0;
  for (int i = 0; i < d; i++) {
    var a = votes[i][0];
    var b = votes[i][1];
    var total = a + b;
    var maj = total / 2 + 1;
    char win;
    int wasteA, wasteB;
    if (a > b) {
      win = 'A';
      wasteA = a - maj;
      wasteB = b;
    }
    else {
      win = 'B';
      wasteA = a;
      wasteB = b - maj;
    }
    cout << win << ' ' << wasteA << ' ' << wasteB << endl;
    totalVotes += total;
    totalWasteA += wasteA;
    totalWasteB += wasteB;
  }
  cout << abs(totalWasteA - totalWasteB) / (double)totalVotes << endl;
}
