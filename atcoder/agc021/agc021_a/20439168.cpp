// detail: https://atcoder.jp/contests/agc021/submissions/20439168
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll l;
  cin >> l;
  string s = to_string(l);
  var digsum = [](string s) {
    int res = 0;
    for (var&& c : s) res += c - '0';
    return res;
  };
  int res = digsum(to_string(l));
  ll dig = 1;
  for (int i = s.size() - 1; i >= 0; i--) {
    var c = s[i] - '0';
    l -= dig * c;
    if (l != 0) chmax(res, digsum(to_string(l - 1)));
    dig *= 10;
  }
  cout << res << endl;
}
