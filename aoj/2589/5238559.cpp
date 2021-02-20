// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2589/judge/5238559/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  while (cin >> s, s != "#") {
    ll num = s.back() == 'h' ? 0 : 90;
    int ind = ((int)s.size()) - (s.back() == 'h' ? 6 : 5);
    ll div = 1;
    while (0 <= ind) {
      num *= 2;
      div *= 2;
      if (s[ind] == 'h') { num -= 90; ind -= 5; continue;
      }
      if (s[ind] == 't') { num += 90; ind -= 4; continue; }
      assert(false);
    }
    while (num % 2 == 0 && div % 2 == 0) { num /= 2; div /= 2; }
    cout << num;
    if (div != 1) cout << '/' << div;
    cout << endl;
  }
}

