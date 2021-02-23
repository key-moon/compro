// detail: https://atcoder.jp/contests/arc080/submissions/20445466
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  int four = 0;
  int single = 0;
  bool hasTwo = false;
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    if (a % 4 == 0) four++;
    else if (a % 2 == 0) hasTwo |= true;
    else single++;
  }
  cout << (four + (hasTwo ? 0 : 1) >= single ? "Yes" : "No") << endl;
}
