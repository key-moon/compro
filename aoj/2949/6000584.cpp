// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2949/judge/6000584/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

ll count_occurence(string& s, string& target) {
  ll cnt = 0;
  for (int i = target.size(); i <= s.size(); i++) {
    if (s.substr(i - target.size(), target.size()) == target) cnt++;
  }
  return cnt;
}

string substr_from_end(string& s, ll len) {
  return s.substr(s.size() - len);
}


string Target;
struct Data {
  bool has_after;
  string prev;
  string after;
  ll cnt;

  Data(string& prev, string& after, ll cnt) : has_after(true), prev(prev), after(after), cnt(cnt) {}
  Data(string& s) : has_after(false), prev(s), after(), cnt(0) {}

  Data operator+(Data& a) {
    ll new_cnt = cnt + a.cnt;
    if (!has_after) {
      var new_prev = prev + a.prev;
      new_cnt += count_occurence(new_prev, Target);
      if (a.has_after) {
        assert(Target.size() - 1 <= new_prev.size());
        var p = new_prev.substr(0, Target.size() - 1);
        return Data(p, a.after, new_cnt);
      }
      else {
        if (Target.size() <= new_prev.size()) {
          var p = new_prev.substr(0, Target.size() - 1);
          var a = substr_from_end(new_prev, Target.size() - 1);
          return Data(p, a, new_cnt);
        }
        else {
          return Data(new_prev);
        }
      }
    }
    else {
      string middle = after + a.prev;
      new_cnt += count_occurence(middle, Target);
      if (a.has_after) {
        return Data(prev, a.after, new_cnt);
      }
      else {
        assert(Target.size() - 1 <= middle.size());
        var a = substr_from_end(middle, Target.size() - 1);
        return Data(prev, a, new_cnt);
      }
    }
    assert(false);
  }
  // kasu
  Data operator*(ll cnt) {
    string empty{};
    Data res(empty), tmp(*this);
    while (cnt) {
      if (cnt & 1) res = res + tmp;
      tmp = tmp + tmp;
      cnt >>= 1;
    }
    return res;
  }
};

Data parse(string& s, int& pos) {
  assert(pos < s.size());
  if (s[pos] == '(') {
    pos++;
    string empty{};
    Data res(empty);
    while (s[pos] != ')') {
      var parsed = parse(s, pos);
      res = res + parsed;
    }
    pos++;
    return res;
  }
  if ('0' <= s[pos] && s[pos] <= '9') {
    ll cnt = 0;
    while ('0' <= s[pos] && s[pos] <= '9') {
      cnt = cnt * 10 + s[pos] - '0';
      pos++;
    }
    Data res = parse(s, pos);
    res = res * cnt;
    return res;
  }
  {
    var res_str = s.substr(pos, 1);
    Data res(res_str);
    pos++;
    return res;
  }
}

bool solve() {
  string s, q;
  cin >> s;
  if (s == "#") return false;
  cin >> q;
  Target = q;
  s = "(" + s + ")";
  int pos = 0;
  var res = parse(s, pos);
  cout << res.cnt << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);

  while (solve());
}

