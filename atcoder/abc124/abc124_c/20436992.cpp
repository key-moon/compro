// detail: https://atcoder.jp/contests/abc124/submissions/20436992
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  char curc = '0';
  int res1 = 0;
  int res2 = 0;
  for (var&& c : s) {
    if (c == curc) res1++;
    else res2++;
    curc ^= '0' ^ '1';
  }
  cout << min(res1, res2) << endl;
}
