// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2931/judge/6005450/C++17
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
  vector<int> apos(n);
  int ind = 0;
  for (var&& elem : a) {
    cin >> elem;
    elem--;
    apos[elem] = ind++;
  }
  vector<bool> used(n);
  string res = "";
  int nxt = 0;
  int max_pos = -1;
  for (var&& pos : apos) {
    res += '(';
    used[pos] = true;
    chmax(max_pos, pos);
    while (nxt < used.size() && used[nxt]) {
      res += ')';
      nxt++;
    }
  }
  int a_ind = 0;
  int cnt = 0;
  stack<int> s{};
  for (var&& c : res) {
    if (c == '(') {
      s.emplace(cnt++);
      continue;
    }
    var elem = s.top(); s.pop();
    if (a[a_ind++] != elem) {
      cout << ":(" << endl;
      return 0;
    }
  }
  cout << res << endl;
  return 0;
}


