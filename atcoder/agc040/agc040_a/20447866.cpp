// detail: https://atcoder.jp/contests/agc040/submissions/20447866
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
  ll res = 0;
  ll streak = 0;
  char prev = '#';
  ll prevMax = 0;
  var resolve = [&]() {
    res += streak * (streak + 1) / 2;
    if (prev == '>') res -= min(streak, prevMax);
    else prevMax = streak;
  };
  for (var&& c : s) {
    if (prev != c) {
      resolve();
      streak = 0;
    }
    prev = c;
    streak++;
  }
  resolve();
  cout << res << endl;
}
