// detail: https://atcoder.jp/contests/abc082/submissions/20448257
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
  map<int, int> cnts{};
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    cnts[a]++;
  }
  int res = 0;
  for (var&& elem : cnts) {
    if (elem.first <= elem.second) {
      res += elem.second - elem.first;
    }
    else {
      res += elem.second;
    }
  }
  cout << res << endl;
}
