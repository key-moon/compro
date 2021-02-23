// detail: https://atcoder.jp/contests/agc013/submissions/20444012
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
  vector<int> a(n);
  for (int i = 0; i < n; i++) cin >> a[i];
  var solve = [](vector<int> a) {
    int res = 0;
    int prev = a.front();
    int sign = 0;
    for (var&& elem : a) {
      var d = prev - elem;
      var curSign = d == 0 ? 0 : abs(d) / d;
      if (sign * curSign == -1) {
        res++;
        sign = 0;
      }
      else if (curSign != 0) sign = curSign;
      prev = elem;
    }
    res++;
    return res;
  };
  var res = solve(a);
  reverse(a.begin(), a.end());
  chmin(res, solve(a));
  cout << res << endl;
}
